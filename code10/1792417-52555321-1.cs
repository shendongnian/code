    var finalList=list.Aggregate(
                      new List<int>(),
                      (lst,it)=>{
                                  if (it<0)
                                  {
                                     return new List<int>(0);
                                  }
                                  else
                                  {
                                      lst.Add(it);
                                      return lst;
                                  }
                     });
    
