    public class ToBeIgnoredAttribute:Attribute
    {
    }
    public class Test
    {
        public int Property1 { get; set; }
        [ToBeIgnored]
        public int Property2 { get; set; }
    }
    var type= typeof(Test)// or typeof(T);
    type.GetProperties().ForEach(prop =>
    {
                if (prop.GetCustomAttribute<ToBeIgnoredAttribute>() != null)
                {
                  Console.WriteLine($"//Call Map with right overload e.g with property name string {prop.Name}"); 
                }
                else
                {
                    Console.WriteLine($"{prop.Name} is not ignored");
                }
            });
