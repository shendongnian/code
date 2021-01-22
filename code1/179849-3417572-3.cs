    List<int> myList = new List<int>(){1, 2, 3};
    IList<int> myIList = myList;
    IEnumerable<int> myIEnumerable = myList;
      //works by List<T>.Contains()
    db.Customers.Where(c => myList.Contains(c.CustomerID));
      //doesn't work, no translation for IList<T>.Contains
    db.Customers.Where(c => myIList.Contains(c.CustomerID));
      //works by Enumerable.Contains<T>()
    db.Customers.Where(c => myIEnumerable.Contains(c.CustomerID));
      //works by Enumerable.Contains<T>()
    db.Customers.Where(c => Enumerable.Contains(myIEnumerable, c.CustomerID));
