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
    public static class MyGenericClass<T> where T : BaseType
    {
        public static IEnumerable<T> ReturnMyType(Func<T, bool> predicate)
        {
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
            var myType = typeof(MyGenericClass<>);
            // create a generic type
            var myGenericType = myType.MakeGenericType(lookupType);
            var method = myGenericType.GetMethod("ReturnMyType", BindingFlags.Static | BindingFlags.Public);
            // invoke the static method
            var func = new Func<BaseType, bool>(item => item.RefName.StartsWith("Test"));
            IEnumerable<BaseType> result = (IEnumerable<BaseType>)method.Invoke(null, new object[] { func });
            foreach (var item in result)
                Console.WriteLine(item.RefName);
            Console.ReadKey();
        }
    }
