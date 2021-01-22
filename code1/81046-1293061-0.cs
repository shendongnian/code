    private static object ExecuteStaticMethod(string method_full_path, object[] args)
          {
             var tokens = method_full_path.Split('.');
             string class_full_name = String.Format("{0}.{1}", tokens[0], tokens[1]);
             var class_blueprint = Assembly.GetExecutingAssembly().GetType(class_full_name);
             var handle_to_method = class_blueprint.GetMethod(tokens[2], BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public);
             return handle_to_method.Invoke(null, args);
             
          }
          public static void Main(string[] args)
          {
             Console.WriteLine( ExecuteStaticMethod("temp.User.Exists", new object[] {"Gishu"} ) ); // prints false
             User.Create("Gishu");
             Console.WriteLine(ExecuteStaticMethod("temp.User.Exists", new object[] { "Gishu" }));  // prints true 
          }
