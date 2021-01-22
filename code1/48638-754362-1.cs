    class C {
    
        void Method<T>(T obj)
             where T : ISomeClass {
            list.Add(obj);
        }
        List<ISomeClass> list = new List<ISomeClass>();
    }
