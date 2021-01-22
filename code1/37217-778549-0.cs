    MethodInfo foo1 = (from m in t.GetMethods(BindingFlags.Public | BindingFlags.Static)
                             where m.Name == name
                             && m.GetGenericArguments().Length == genericArgTypes.Length
                             && m.GetParameters().Select(pi => pi.ParameterType.IsGenericType ? pi.ParameterType.GetGenericTypeDefinition() : pi.ParameterType).SequenceEqual(argTypes) &&
                             (returnType==null || (m.ReturnType.IsGenericType ? m.ReturnType.GetGenericTypeDefinition() : m.ReturnType) == returnType)
                             select m).FirstOrDefault();
          if (foo1 != null)
          {
            return foo1.MakeGenericMethod(genericArgTypes);
          }
          return null;
