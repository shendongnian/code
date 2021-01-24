    private static Func<long, byte, AzzObject> GetDataExtractorForTypeWithId(Type type)
            {
                var paramId = Expression.Parameter(typeof(long), "id");
                ParameterExpression paramOptions = null;
                var facadetype = GetFacadeType(type.Name) ?? typeof(AzzFacade<>).MakeGenericType(type);
                MethodInfo loadMethod;
                var linkedEntitiesInterface = facadetype.GetInterface(typeof(IFacadeLoadLinkedEntities<,>).Name);
                if (linkedEntitiesInterface != null)
                {
                    loadMethod = facadetype.GetMethod("LoadById");
                    paramOptions = Expression.Parameter(typeof(byte), "options");
                }
                else
                {
                    paramOptions = Expression.Parameter(typeof(byte));
                    loadMethod = facadetype.GetMethod("LoadByID", new Type[1]{typeof(long)});
                }
                var facadeConstructor = facadetype.GetConstructor(new Type[0]);
                if(facadeConstructor==null)
                    throw new NullReferenceException($"No parameterless constructor found for facade for type {type.Name}");
                MethodCallExpression callLoad;
                var newFacade = Expression.New(facadeConstructor);
                if (linkedEntitiesInterface != null)
                {
                    var conversionExpression = Expression.Convert(paramOptions, linkedEntitiesInterface.GetGenericArguments()[1]);
                    // ReSharper disable once AssignNullToNotNullAttribute
                    callLoad = Expression.Call(newFacade, loadMethod, paramId, conversionExpression);
                }
                else
                {
                    // ReSharper disable once AssignNullToNotNullAttribute
                    callLoad = Expression.Call(newFacade, loadMethod, paramId);
                }
                
                var lambda = Expression.Lambda<Func<long, byte, AzzObject>>(
                    // ReSharper disable once AssignNullToNotNullAttribute
                    callLoad, paramId, paramOptions);
                //compiles the Expression to a usable delegate.
                return lambda.Compile();
            }
