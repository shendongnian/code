     object obj = null;
     Type[] types = new Type[] { typeof(TypeA), typeof(List<TypeB>) };
     if (TryDeserialize(json, out obj, types))
     {
         if (obj is TypeA)
         {
             var r = obj as TypeA;
         }
         else
         {
             var r = obj as List<TypeB>;
         }
     }
