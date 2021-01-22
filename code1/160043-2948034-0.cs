            ServiceContainer container = new ServiceContainer();
            IList<int> integers = new List<int>();
            IList<string> strings = new List<string>();
            IList<double> doubles = new List<double>();
            container.AddService(typeof(IEnumerable<int>), integers);
            container.AddService(typeof(IEnumerable<string>), strings);
            container.AddService(typeof(IEnumerable<double>), doubles);
