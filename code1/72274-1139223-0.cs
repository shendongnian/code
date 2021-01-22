    var l1 = new List<int>() { 1,2,3,4,5,2,2,2,4,4,4,1 };
    
    var g = l1.GroupBy( i => i );
    
    foreach( var grp in g )
    {
      Console.WriteLine( "{0} {1}", grp.Key, grp.Count() );
    }
