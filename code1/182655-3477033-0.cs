    var query = objectA.Where(a => a.type == 1)
                       .Select(a => {
                                   string Field2;
                                   string Field3;
                                   TestMethod(a, out Field2, out Field3);
                                   return new {
                                       a.Id, Field2, Field3
                                   };
                               });
                       .ToList();
