      static string PrettyPrintGenericTypeName(Type typeRef)
      {
         var rootType = typeRef.IsGenericType
            ? typeRef.GetGenericTypeDefinition()
            : typeRef;
         var cleanedName = rootType.IsPrimitive
                              ? rootType.Name
                              : rootType.ToString();
         if (!typeRef.IsGenericType)
            return cleanedName;
         else
            return cleanedName.Substring(0,
                                         cleanedName.LastIndexOf('`'))
                + typeRef.GetGenericArguments()
                         .Aggregate("<",
                                    (r, i) =>
                                       r
                                       + (r != "<" ? ", " : null)
                                       + PrettyPrintGenericTypeName(i))
                + ">";
      }
   
