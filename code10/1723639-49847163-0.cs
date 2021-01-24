    public class Person
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
    
            private string name;
            public string Name
            {
                get { return name; }
                set { otherName = name = value; }
            }
    
    
            private int age;
    
            public int Age
            {
                get { return age; }
                set { otherAge = age = value; }
            }
    
            private string otherName;
    
            public string OtherName
            {
                get { return otherName; }
                set { otherName = value; }
            }
            private int otherAge;
    
            public int OtherAge
            {
                get { return otherAge; }
                set { otherAge = value; }
            }
    
    
        }
