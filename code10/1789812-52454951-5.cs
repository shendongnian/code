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
            var method = myGenericType.GetMethod("SelectData", BindingFlags.Static | BindingFlags.Public);
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
