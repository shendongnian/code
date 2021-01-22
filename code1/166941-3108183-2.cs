    public class MyClass
    {
        // ...
        public static List<MyClass> GetList()
        {
            List<MyClass> list = new List<MyClass>();
            list.Add(new MyClass());
            // ...
            return list;
        }
    }
