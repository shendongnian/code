    //The attribute we're looking at
    public class MyAtt : System.Attribute
    {
        public string name;
        public string anotherstring;
        public MyAtt(string name, string anotherstring)
        {
            this.name = name;
            this.anotherstring = anotherstring;
        }
    }
    public static class Usage
    {
        [MyAtt("String1", "String2")] //Using the attribute
        public static string SomeProperty = "String1";
    }
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(IsEqualToAttribute("String1"));
            Console.WriteLine(IsEqualToAttribute("blah"));
            Console.ReadKey();
        }
        public static bool IsEqualToAttribute(string mystring)
        {
            //Let's get all the properties from Usage
            PropertyInfo[] props = typeof(Usage).GetProperties();
            foreach (var prop in props)
            {
                //Let's make sure we have the right property
                if (prop.Name == "SomeProperty")
                {
                    //Get the attributes from the property
                    var attrs = prop.GetCustomAttributes();
                    //Select just the attribute named "MyAtt"
                    var attr = attrs.SingleOrDefault(x => x.GetType().Name == "MyAtt");
                    MyAtt myAttribute = attr as MyAtt; //Just casting to the correct type
                    if (myAttribute.name == mystring) //Compare the strings
                        return true;
                    if (myAttribute.anotherstring == mystring) //Compare the strings
                        return true;
                }
            }
            return false;
        }
    }
