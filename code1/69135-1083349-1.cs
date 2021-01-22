    public class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthday;
        //...
        
        public class FirstNameComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x._firstName.CompareTo(y._lastName);
            }
        }
    }
