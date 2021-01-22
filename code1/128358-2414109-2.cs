    namespace MyExample
    {
        public abstract class Person
        {
            protected string name;
    
            public Person(string name)
            {
                this.name = name;
            }
    
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
    
            public override string ToString()
            {
                return (this.GetType().Name + " " + name);
            }
        }
    }
