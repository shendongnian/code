    namespace ClassLibrary1
    {
        public class Country
        {
            private readonly HashSet<State> states;
            public Country()
            {
                states = new HashSet<State>();
            }
            public void AddState(State value)
            {
                states.Add(value);
                // Fire event
            }
            public void RemoveState(State value)
            {
                states.Remove(value);
                // Fire event
            }
        }
        public class State {
            public string Code { get; set; }
            public string Name { get; set; }
        }
        public class test {
            public test()
            {
                Country c = new Country();
                // Captured!
                c.AddState(new State { Code = "US", Name = "United States" });
            }
        }
    }
