    public class Student
        {
            private string _Name;
    
            public string Name
            {
                get => string.IsNullOrWhiteSpace(_Name) ? string.Empty : _Name;
                set => _Name = value;
            }
            //todo: rest of properties
        }
