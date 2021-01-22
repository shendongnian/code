     internal static void AnalyzeClasses(Assembly assembly)
     {
         foreach (var type in assembly.GetTypes())
              AnalzyeSingleClass(type);
     }
     internal static void AnalzyeSingleClass(Type type)
     {
         foreach (MyCustomAttribute att in type.GetCustomAttributes(typeof(MyCustomAttribute), false))
         {
              Console.WriteLine("Found MyCustomAttribute with property {0} on class {1}",
                      att.MyCustomAttributeProperty,
                      type);
         }
     }
