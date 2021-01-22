       public void MyFunctionMethodGroup(string methodName, Type type, object caller = null, params Type[] genericParameters)
        {
            //GetMethods only returns public methods. If you need protected/private, modify as appropriate.
            var methods = type.GetMethods().Where(x => x.Name == methodName);
            foreach (var method1 in methods)
            {
                MethodInfo method = method1.IsGenericMethod ? method1.MakeGenericMethod(genericParameters) : method1;
                Type delegateType = Expression.GetDelegateType(
                    method.GetParameters().Select(x => x.ParameterType)
                    .Concat(new[] { method.ReturnType })
                    .ToArray());
                Delegate myDelegate = method.CreateDelegate(delegateType, method.IsStatic ? null : caller);
                MyFunction(myDelegate);
            }
        }
