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
    class Test
    {
        public void Run()
        {
            Guid G1 = Guid.NewGuid();
            Guid G2 = Guid.NewGuid();
            Guid G3 = Guid.NewGuid();
            List<T1> t1s = new List<T1>() {
                new T1(G1, "one"),
                new T1(G2, "two"), 
                new T1(G3, "three") 
            };
            List<Guid> filter = new List<Guid>() { G2, G3};
            List<T1> filteredValues1 = t1s.FindAll(delegate(T1 item)
            {
                return filter.Contains(item.Guid);
            });
            List<T1> filteredValues2 = t1s.FindAll(o1 => filter.Contains(o1.Guid));
        }
    }
