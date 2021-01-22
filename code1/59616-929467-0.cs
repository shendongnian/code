    string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                                      "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                                      "U", "V", "W", "X", "Y", "Z", "Å", "Ä", "Ö", "0-9" };
    
    var result = new Dictionary<int, List<ServiceInfo>>();
    foreach (var letter in letters)
    {
    	var services = (from se in EntityBase.db.Services
                        where se.Name.StartsWith(letter)
                        orderby se.Name
                        select select new ServiceInfo
                        {
                            Letter = letter,
                            Services = EntityBase.db.Services.Where(se => se.Name.StartsWith(letter)).ToList(),
                            Total = EntityBase.db.Services.Where(se => se.Name.StartsWith(letter)).Count()
                        }).ToList();
    	result.Add(i, services);
    }
