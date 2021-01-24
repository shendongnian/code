    List<DateTime> myCollection = new List<DateTime>();
    
    myCollection.Add(Convert.ToDateTime(DateTime.Now));
    myCollection.Add(Convert.ToDateTime(DateTime.Now));
    myCollection.Add(Convert.ToDateTime(DateTime.Now));
    var descendingOrder = myCollection.OrderByDescending(i => i).ToList(); 
          
    string latestDateTime=Convert.ToString(descendingOrder[0]);
