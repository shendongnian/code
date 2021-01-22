        private void Check(Type t, Type i)
        {
            var interfaces = t.GetTopLevelInterfaces();
            Debug.Assert(interfaces != null, "interfaces is null");
            Debug.Assert(interfaces.Length == 1, "length is not 1");
            Debug.Assert(interfaces[0] == i, "the expected interface was not found");
            System.Console.WriteLine("\n{0}", t.ToString());
            foreach (var intf in  interfaces)
                System.Console.WriteLine("  " + intf.ToString());
        }
        public void Run()
        {
            Check(typeof(Foo), typeof(IEnumerable<int>));
            Check(typeof(Bar), typeof(IDisposable));
        }
