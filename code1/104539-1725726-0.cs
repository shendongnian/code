        class T1
        {
            public T1(Guid g, string n) { Guid = g; MyName = n; }
            public Guid Guid { get; set; }
            public string MyName { get; set; }
        }
        class T2
        {
            public T2(Guid g, string n) { ID = g; Name = n; }
            public Guid ID { get; set; }
            public string Name { get; set; }
        }
        public class Test    {
            public Run()
            {
    
            Guid G1 = Guid.NewGuid();
            Guid G2 = Guid.NewGuid();
            List<T1> t1s = new List<T1>(){new T1(G1,"one"), new T1(G2,"two")};
            List<T2> t2s = new List<T2>() { new T2(new Guid(), "one") };
            List<Guid> filter = new List<Guid>() { G2 };
    
            List<T1> filteredValues = t1s.FindAll(delegate(T1 item)
            {
                return filter.Exists(delegate(Guid g){
                    return g.Equals(item.Guid);
                });
            });
    }
    }
