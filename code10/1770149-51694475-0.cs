      var arg = typeof( Base<> ).GetGenericArguments()[ 0 ];
      Console.WriteLine( arg.DeclaringType ); // Base`1[T]
    
      arg = typeof( Child<> ).BaseType.GetGenericArguments()[ 0 ];
      Console.WriteLine( arg.DeclaringType ); // Child`1[T]
