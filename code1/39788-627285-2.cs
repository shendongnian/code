    public abstract class Animal : IAnimal
        {
            public Animal(string name)
            {
                this.WhatIsMyName = name;
            }
            public string WhatIsMyName { get; private set; }
            public abstract string WhatAmI { get; }
        }
