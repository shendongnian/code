    public class MyExtensMethods{
        public static T GetPropertyValue<T>(this Object obj, string property)
        {
            return (T)obj.GetType().GetProperty(property).GetValue(obj, null);
        }
    }
    class SomeClass
    {
        public int ID{get;set;}
        public int FullName{get;set;}
    }
    
    // casts obj to type SomeClass
    public SomeClass CastToSomeClass(object obj)
    {
         return new SomeClass()
         {
             ID = obj.GetPropertyValue<int>("Id"),
             FullName = obj.GetPropertyValue<string>("LastName") + ", " + obj.GetPropertyValue<string>("FirstName")
         };
    }
