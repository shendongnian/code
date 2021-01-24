        var newType = assembly.GetTypes().SingleOrDefault(x => x.FullName == argType.FullName + "Suffix");
         if(newType.IsGenericType)
         {
            // Get the generic type parameters or type arguments.
            Type[] typeParameters = t.GetGenericArguments();
            // Construct the type Dictionary<String, Example>.
            Type constructed = newType.MakeGenericType(typeParameters);
         }
