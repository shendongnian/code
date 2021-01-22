       /// <summary>
       /// Sort class on LastName Descending Order
       /// </summary>
       private class PersonLastNameDescending : IComparer<Person>
       {
          public int Compare(Person aX, Person aY)
          {
             return aY.LastName.CompareTo(aX.LastName);
          } // end Compare(...)
       } // end inner class PersonLastNameDescending 
    
       MyPeople.Sort(new PersonLastNameDescending());
