    static class Program
    {
        static void Main()
        {
            Console.WriteLine(MyDisplayNameAttribute.Get(
                typeof(Foo), "NameFirst"));
            Console.WriteLine(MyDisplayNameAttribute.Get(
                typeof(Foo), "Bar"));
        }
    }
    [AttributeUsage(AttributeTargets.Interface |
        AttributeTargets.Class | AttributeTargets.Struct,
        AllowMultiple = true, Inherited = true)]
    sealed class MyDisplayNameAttribute : Attribute
    {
        public string MemberName { get; private set; }
        public string DisplayName { get; private set; }
        public MyDisplayNameAttribute(string memberName, string displayName)
        {
            MemberName = memberName;
            DisplayName = displayName;
        }
        public static string Get(Type type, string memberName)
        {
            var attrib = type.GetCustomAttributes(
                    typeof(MyDisplayNameAttribute), true)
                .Cast<MyDisplayNameAttribute>()
                .Where(x => x.MemberName.Equals(memberName,
                    StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();
            return attrib == null ? memberName : attrib.DisplayName;
        }
    }
    [MyDisplayName("NameFirst", "First Name")]
    [MyDisplayName("AgencyName", "Agency")]
    partial class Foo { } // your half of the entity
    partial class Foo { // LINQ-generated
        public string NameFirst {get;set;}
        public string AgencyName {get;set;}
        public string Bar { get; set; }
    }
