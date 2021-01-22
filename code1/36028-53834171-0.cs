    public class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
    
            public override bool Equals(object other)
            {
                Person otherItem = other as Person;
    
                if (otherItem == null)
                    return false;
    
                return Age == otherItem.Age && Name == otherItem.Name;
            }
            public override int GetHashCode()
            {
                int hash = 13;
                hash = (hash * 7) + Age.GetHashCode();
                hash = (hash * 7) + Name.GetHashCode();
                return hash;
            }
        }
