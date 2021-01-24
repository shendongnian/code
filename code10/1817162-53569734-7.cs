    namespace Models
    {
        public class Station
        {
            public Station(string name)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("message", nameof(name));
                }
    
                Name = name;
            }
    
            public string Name { get; }
        }
    }
