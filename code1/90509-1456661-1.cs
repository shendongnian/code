        Type type = ...
        var qry = from method in type.GetMethods(
                      BindingFlags.Instance | BindingFlags.Public)
                  where method.ReturnType == typeof(void)
                  let parameters = method.GetParameters()
                  where parameters.Length == 1
                  && parameters[0].ParameterType.IsArray
                  && Attribute.IsDefined(parameters[0], typeof(ParamArrayAttribute))
                  select method;
        foreach (var method in qry)
        {
            Console.WriteLine(method.Name);
        }
