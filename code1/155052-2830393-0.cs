      static void Main(string[] args)
      {
         ClassA a = new ClassA();
         int half_arg_length = args.Length / 2;
         System.Type[] param_types = new Type[half_arg_length];
         object[] param_values = new object[half_arg_length];
         for (int i = 0; i < half_arg_length; i++)
         {
            string string_type = args[i * 2 + 1];
            param_types[i] = System.Type.GetType(string_type);
            Type convert_type = System.Type.GetType(string_type.TrimEnd('&'));
            param_values[i] = Convert.ChangeType(args[i * 2 + 2], convert_type);
         }
         MethodInfo callInfo = typeof(ClassA).GetMethod(args[0], param_types);
         object res = callInfo.Invoke(a, param_values);
      }
