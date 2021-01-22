    public class Example
    {
        private Dictionary<int, string> exampleDictionary;
        public Example() 
        { 
            exampleDictionary = new Dictionary<int, string>(); 
        }
        public IReadOnlyDictionary<int, string> ExampleDictionary
        {
            get { return (IReadOnlyDictionary<int, string>)exampleDictionary; }
        }
    }
