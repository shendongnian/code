     var quantity = ...
     var query = db.Model.Select( m => new
                                      {
                                        Name = m.Name,
                                        Price = m.Price,
                                        Cost = M.Price * quantity
                                      } );
     foreach (var q in query)
     {
         Console.WriteLine( q.Name );
         Console.WriteLine( q.Price );
         Console.WriteLine( q.Cost );
     }
