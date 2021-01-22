    public abstract class Animal : IAnimal
    {
        private string _name;
        public abstract string WhatAmI { get; }
        public string WhatIsMyName
        {
            get { return _name; }
        }
        public Animal(string name)
        {
            _name = name;
        }
    }
