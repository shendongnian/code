        private void Foo()
        {
            TestJan myObject = CreateObject<TestJan>("Jan", 21);
        }
        private T CreateObject<T>(string name, int age)
        {
            //first get a reference to the ConstructorInfo
            //we know constructor has 2 params, string and int32. Names are not important.
            System.Reflection.ConstructorInfo ci = typeof(T).GetConstructor(new[] { typeof(string), typeof(int) });
            //we now have to define the types
            ParameterExpression stringParam = Expression.Parameter(typeof(string), "stringExp");
            ParameterExpression intParam = Expression.Parameter(typeof(int), "intExp");
            //create an expression
            NewExpression constructor = Expression.New(ci, stringParam, intParam);
            //wrap this in a lambda-expression, which returns basically
            //    (stringExp, intExp) => new T(stringExp, intExp);
            LambdaExpression lambda = Expression.Lambda(constructor, stringParam, intParam);
            //compile into delegate
            var constructorDelegate = (Func<string, int, T>)lambda.Compile();
            //invoke the delegate. Normally you would cache this in a static Dictionary<Type, Delegate>.
            //when you cache this, it's lightning fast. As it's just as fast as hard program
            //    (stringExp, intExp) => new T(stringExp, intExp);
            return constructorDelegate.Invoke(name, age);
        }
