    namespace GetSet
    {
        public class Role
        {
            // private backing field
            private string _weapon;
    
            // properties can have getters and setters, that contains some logic
            public string Weapon
            {
                get { return _weapon; }
                set { if (_weapon != vale) _weapon = value; }
            }
            // there is an auto-getters/setters
            // in this case, backing field is handled by .Net CLR
            public string Armour { get; set; }
            // getters and setters may have different access level
            // also, note property initializer '= "John";' - this will set property value
            // to "John" right before constructor invocation
            public string Name { get; private set; } = "John";
            // properties also can be readonly, so they can be setted only in constructors
            public string Passive { get; }
            // public constructor
            public Role(string passive)
            {
                Passive = passive;
            }
            public void ChangeName(string newName)
            {
                Name = newName; // setting property through private setter
            }
            // I believe, that this method shouldn't be used to represent object as string
            // At least, I think, you should never relay on it's return value, BUT it ups to you
            public overide string ToString() => Name;
        }
    }
