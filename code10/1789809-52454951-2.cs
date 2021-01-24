    // The basetype of an item (which contains de RefName etc)
    public class BaseType
    {
        public string RefName { get; set; }
        public string Tag { get; set; }
    }
    // static T service
    public static class Data<T> where T : BaseType
    {
        public static List<T> MyData { get; } = new List<T>();
        static Data()
        {
            // create an item
            var item = Activator.CreateInstance<T>();
            item.RefName = "Test";
            item.Tag = "Bla";
            MyData.Add(item);
            var item2 = Activator.CreateInstance<T>();
            item2.RefName = "SomethingElse";
            item2.Tag = "TagThing";
            MyData.Add(item2);
            var item3 = Activator.CreateInstance<T>();
            item3.RefName = "Test2";
            item3.Tag = "Bla2";
            MyData.Add(item3);
        }
    }
    // the generic class which uses the basetype as generic
    public static class DocumentDBRepository<T> where T : BaseType
    {
        public static IEnumerable<T> SelectData(Func<T, bool> predicate)
        {
            // some static test data
            return Data<T>.MyData.Where(predicate);
        }
    }
    // your derived class from BaseType
    public class MyLookupThing : BaseType
    {
    }
    class TestReflection
    {
        public TestReflection()
        {
            // you can create more classes derived from BaseType 
            var typeStr = "TestRef.MyLookupThing";
            // resolve the type:
            var lookupType = (from ass in AppDomain.CurrentDomain.GetAssemblies()
                              from t in ass.GetTypes()
                              where t.FullName == typeStr
                              select t).First();
            // get the type of the generic class
            var myType = typeof(DocumentDBRepository<>);
            // create a generic type
            var myGenericType = myType.MakeGenericType(lookupType);
            var method = myGenericType.GetMethod("ReturnMyType", BindingFlags.Static | BindingFlags.Public);
            // Create the expression (with the BaseType)
            var func = new Func<BaseType, bool>(item => item.RefName.StartsWith("Test"));
            // invoke the method of the generic class
            IEnumerable<BaseType> result = (IEnumerable<BaseType>)method.Invoke(null, new object[] { func });
            // show the results
            foreach (var item in result)
                Console.WriteLine(item.RefName);
            Console.ReadKey();
        }
    }
