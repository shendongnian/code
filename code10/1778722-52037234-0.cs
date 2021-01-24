    List<List<MyObj>> lst;
    var result = lst.where(x => 
                 {
                   // Assuming ID to be string type
                   var hashset = new Hashset<string>(x.Select(y => y.ID));
                   return hashset.Contains("1");
                  }
               );
