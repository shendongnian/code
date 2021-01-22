    public class Test
    {
        class DummyInterfaceImplementor : IDummyInterface
        {
            public string A { get; set; }
            public string B { get; set; }
        }
        public void WillThisWork()
        {
            var source = new DummySource[0];
            var values = from value in source
                         select new DummyInterfaceImplementor()
                         {
                             A = value.A,
                             B = value.C + "_" + value.D
                         };
            DoSomethingWithDummyInterface(values.Cast<IDummyInterface>());
        }
        public void DoSomethingWithDummyInterface(IEnumerable<IDummyInterface> values)
        {
            foreach (var value in values)
            {
                Console.WriteLine("A = '{0}', B = '{1}'", value.A, value.B);
            }
        }
    }
