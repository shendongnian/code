    var result =dataObjectList.Join(filterObjectList, 
                               d=>d.Username, 
                               f=>f.Username,
                               (x,y)=> new 
                                  {
                                    Data = x, 
                                    Filter=y
                                  })
    				          .Where(x=>x.Data.Username.Equals(x.Filter.Username) 
                                 && x.Data.Password.Equals(x.Filter.Password))
                             .Select(x=>x.Data);;
