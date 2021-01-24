        public class NameExample
        {
            private string name;
            private string firstName;
            private string lastName;
            public string Name
            {
                get { return name;  }
                set
                {
                    if( value != name )
                    {
                        name = value;
                        if (string.IsNullOrEmpty(name)) return;
                        var names = name.Split(' ');
                        firstName = names[0];
                        if (names.Length > 1) lastName = names[1]; // Is our person Cher? ;-)
                    }
                }
            }
            public string FirstName
            {
                get
                {
                    return firstName;
                }
                set
                {
                    firstName = value;
                    name = firstName + (string.IsNullOrEmpty(lastName) ? "" : " " + lastName);
                }
            }
            
            public string LastName
            {
                get => lastName;
                set {
                    lastName = value;
                    name = firstName + (string.IsNullOrEmpty(lastName) ? "" : " " + lastName);
                }
            }
