     public enum ReflectionFields
    {
        CITY = 0,
        STATE,
        ZIP,    
        COUNTRY
    }
    [AttributeUsage(AttributeTargets.Field,AllowMultiple=false)]
    public class CustomFieldAttr : Attribute
    {
        public ReflectionFields Field { get; private set; }
        public string MiscInfo { get; private set; }
        public CustomFieldAttr(ReflectionFields field, string miscInfo)
        {
            Field = field;
            MiscInfo = miscInfo;
        }
    }
    public class Person
    {
        [CustomFieldAttr(ReflectionFields.CITY, "This is the primary city")]
        public string _city = "New York";
        public Person()
        {
        }
        public Person(string city)
        {
            _city = city;
        }
      
    }
    public static class AttributeReader<T> where T:class
    {
        public static void Read(T t)
        {
            //get all fields which have the "CustomFieldAttribute applied to it"
            var fields = t.GetType().GetFields().Where(f => f.GetCustomAttributes(typeof(CustomFieldAttr), true).Length == 1);
            foreach (var field in fields)
            {
                var attr = field.GetCustomAttributes(typeof(CustomFieldAttr), true).First() as CustomFieldAttr;
                if (attr.Field == ReflectionFields.CITY)
                {
                    //You have the field and you know its the City,do whatever processing you need.
                    Console.WriteLine(field.Name);
                }
            }            
        }
    }
	
    public class Program
    {
        public static void Main(string[] args)
        {
            PPerson p1 = new PPerson("NewYork");
            PPerson p2 = new PPerson("London");
            AttributeReader<PPerson>.Read(p1);
            AttributeReader<PPerson>.Read(p2);
	}
     }
