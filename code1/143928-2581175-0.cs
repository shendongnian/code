    using System;
    using System.Configuration;
    using System.Reflection;
    
    namespace ConsoleApplication1 {
      class Program {
        static void Main(string[] args) {
          var all = typeof(Properties.Settings).GetProperties();
          foreach (var prop in all) {
            var attr = (SettingsDescriptionAttribute[])prop.GetCustomAttributes(typeof(SettingsDescriptionAttribute), false);
            if (attr.Length > 0) 
              Console.WriteLine("{0}: {1}", prop.Name, attr[0].Description);
          }
          Console.ReadLine();
        }
      }
    }
