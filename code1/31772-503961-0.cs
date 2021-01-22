     public class Parent : IComparable<Parent>
        {
            public int Age { get; set; }
    
    
            public int CompareTo(Parent other)
            {
                
                return this.Age.CompareTo(other.Age);
            }
    
        }
    
        public class Child : Parent
        {
            public string Name { get; set; }
        }
