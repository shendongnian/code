    public class dictionaryviewmodel
    {
        public class dictionaryviewmodel
        {
            //this getter will create dictionary instance only once
            //and will always return the same instance with previously added values
            //also it instantiates dpdnDict object
            public dictionary dictInViewModel { get; } = new dictionary()
            {
                dpdnDict = new Dictionary<string, string>()
            };
        }
    }
