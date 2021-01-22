        public void Run()
        {
            var interfaces = typeof(Foo).GetTopLevelInterfaces();
            Debug.Assert(interfaces != null, "interfaces is null");
            Debug.Assert(interfaces.Length == 1, "length is not 1");
            Debug.Assert(interfaces[0] == typeof(IEnumerable<int>), "the expected interface was not found");
            foreach (var intf in  interfaces)
            {
                System.Console.WriteLine(intf.ToString());
            }
        }
