            Type[] allInterfaces = typeof(Foo).GetInterfaces();
            var interfaces = allInterfaces.Where(x => x == typeof(IEnumerable<int>)).ToArray();
            Debug.Assert(interfaces != null);
            Debug.Assert(interfaces.Length == 1);
            Debug.Assert(interfaces[0] == typeof(IEnumerable<int>));
