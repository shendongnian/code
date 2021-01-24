    using System;
    using System.Reflection;
    
    class Reference<T> {}
    interface IDomainObject {}
    
    interface IRepository
    {
        string GetId<T>(T obj) where T : IDomainObject;
        string GetId<T>(Reference<T> reference) where T : IDomainObject;
    }
    
    class Test
    {
        static void Main()
        {
            var method = GetReferenceAcceptingGetIdMethod();
            Console.WriteLine(method);
        }
        
        public static MethodInfo GetReferenceAcceptingGetIdMethod()
        {
            var repositoryInterfaceType = typeof(IRepository);
            foreach (var m in repositoryInterfaceType.GetMethods())
            {
                if (m.IsGenericMethodDefinition && m.Name == nameof(IRepository.GetId))
                {
                    var typeParameter = m.GetGenericArguments()[0];
                    var expectedParameterType = typeof(Reference<>).MakeGenericType(typeParameter);
                    var parameters = m.GetParameters();
                    if (parameters.Length == 1)
                    {
                        var firstParamType = parameters[0].ParameterType;
                        if (firstParamType == expectedParameterType)
                        {
                            return m;
                        }
                    }
                }
            }        
            throw new Exception();
        }
    }
