        public class Baz
        {
            [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
            public readonly List<Foo> Foos;
            public Baz()
            {
                Foos = new List<Foo>();
            }
        }
    This solution results in less bloated JSON and also minimizes the security risks of using `TypeNameHandling` that are described in *https://stackoverflow.com/q/39565954/3744182* and *https://stackoverflow.com/q/49038055/3744182* and thus is the preferable solution.
