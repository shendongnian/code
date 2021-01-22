        public class Parent : IComparable
        {
        public int Age { get; set; }
    
    
        public int CompareTo(object other)
        {
            Parent p = other as Parent;
            return this.Age.CompareTo(p.Age);
        }
    
    }
    
        public class Child : Parent
        {
            public string Name { get; set; }
        }
