    var outputs = inputs
                      .SelectMany(input =>
                        input
                          .A.Keys               // all key from A
                          .Union(input.B.Keys)  // + all key from B without the duplicate
                          .Select(k =>
                            new Output
                             {
                                Key = k,
                                A = input.A.GetValueOrDefault(k),
                                B = input.B.GetValueOrDefault(k)
                             }
                           ) 
                       );                      
                       
                       
