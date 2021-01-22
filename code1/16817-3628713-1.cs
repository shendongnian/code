    public static MethodInfo GetGenericMethod(
      this Type type, string name, Type[] generic_type_args, Type[] param_types, bool complain = true)
    {
      foreach (MethodInfo m in type.GetMethods())
        if (m.Name == name)
        {
          ParameterInfo[] pa = m.GetParameters();
          if (pa.Length == param_types.Length)
          {
            MethodInfo c = m.MakeGenericMethod(generic_type_args);
            if (c.GetParameters().Select(p => p.ParameterType).SequenceEqual(param_types))
              return c;
          }
        }
      if (complain)
        throw new Exception("Could not find a method matching the signature " + type + "." + name +
          "<" + String.Join(", ", generic_type_args.AsEnumerable()) + ">" +
          "(" + String.Join(", ", param_types.AsEnumerable()) + ").");
      return null;
    }
