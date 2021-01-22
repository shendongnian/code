    public abstract class TypeBasedFactory<TInput, TOutput>
        where TInput : class where TOutput : class
    {
        private readonly Dictionary<Type, Func<TInput, TOutput>> factories;
        protected TypeBasedFactory()
        {
            factories = CreateFactories();
        }
        private Dictionary<Type, Func<TInput, TOutput>> CreateFactories()
        {
            return GetType()
                .GetMethods(
                    BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance)
                .Where(methodInfo =>
                    !methodInfo.IsAbstract
                    && methodInfo.GetParameters().Length == 1
                    && typeof(TOutput).IsAssignableFrom(methodInfo.ReturnType))
                .Select(methodInfo => new
                {
                    MethodInfo = methodInfo,
                    methodInfo.GetParameters().First().ParameterType
                })
                .Where(factory =>
                    typeof(TInput).IsAssignableFrom(factory.ParameterType)
                    && !factory.ParameterType.IsAbstract)
                .ToDictionary(
                    factory => factory.ParameterType,
                    factory => CreateFactory(factory.MethodInfo, factory.ParameterType));
        }
        private Func<TInput, TOutput> CreateFactory(MethodInfo methodInfo, Type parameterType)
        {
            // Create this Func<TInput, TOutput>: (TInput input) => Method((Parameter) input)
            var inputExpression = Expression.Parameter(typeof(TInput), "input");
            var castExpression = Expression.Convert(inputExpression, parameterType);
            var callExpression = Expression.Call(Expression.Constant(this), methodInfo, castExpression);
            var lambdaExpression = Expression.Lambda<Func<TInput, TOutput>>(callExpression, inputExpression);
            return lambdaExpression.Compile();
        }
        public TOutput CreateFrom(TInput input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            var inputType = input.GetType();
            Func<TInput, TOutput> factory;
            if (!factories.TryGetValue(inputType, out factory))
                throw new InvalidOperationException($"No factory method defined for {inputType.FullName}.");
            return factory(input);
        }
    }
