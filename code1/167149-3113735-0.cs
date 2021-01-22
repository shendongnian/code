    class LastNameComparer : IComparer<Person>
    {
       public int Compare(Person x, Person y)
       {
           return String.Compare(x.LastName, y.LastName);
       }
    }
