    var lines = File.ReadAllLines(@"C:\file.csv");
    
    var csv = lines.Select(x =>{
                                  var parts = x.Split(',');
                                  return new Department()
                                           {
                                              id = parts[0].Trim(),
                                              name = parts[1].Trim(),
                                           };
                               }).ToList();
