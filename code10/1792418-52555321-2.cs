    var finalList=list.Aggregate(
                      new List<int>(),
                      (lst,it)=>{
                                  if (it<0)
                                  {
                                     return new List<int>();
                                  }
                                  else
                                  {
                                      lst.Add(it);
                                      return lst;
                                  }
                     });
    
