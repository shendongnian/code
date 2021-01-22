    foreach (var Ass in AppDomain.CurrentDomain.GetAssemblies())
    {
         // Use the above "If" condition if you want to filter from only one Dll
         if (Ass.ManifestModule.FullyQualifiedName.EndsWith("YourDll.dll"))
         {
                List<Type> lstClasses = Ass.GetTypes().Where(t => t.IsClass && t.IsSealed && t.IsAbstract).ToList();
                foreach (Type type in lstClasses)
                {
                      MethodInfo methodInfo = type.GetMethod("ResetValues");
                      if (methodInfo != null)
                      {
                           object result = null;
                           result = methodInfo.Invoke(null, null);                                
                      }
                 }
                 break;
        }
    }
