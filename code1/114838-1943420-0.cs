        public abstract class Animal
        {
            private int _originalHash;
            public string Name { get; set; }
            public int Age { get; set; }
            public Animal(string name, int age)
            {
                this.Name = name;
                this.Age = age;
                this._originalHash = GetHashCode();
            }
            public override sealed int GetHashCode()
            {
                unchecked
                {
                    return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ Age;
                }
            }
            public bool IsDirty
            {
                get
                {
                    return this._originalHash != GetHashCode();
                }
            }
        }
        public class Cat : Animal
        {
            public Cat(string name, int age)
                : base(name, age)
            {
            }
        }
