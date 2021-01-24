    foreach (DataRow item in datatable.Rows)
    {
                    int idObj = (int)item["id"] //This Id for both, right?           
                    addresses.Add(new address
                    {
                        id = idObj,
                        peopleaddress = item["address"].ToString(),
                    });
    
                    peopleslist.Add(new People
                    {
                        id = (int)item["id"],
                        Name = item["name"].ToString(),
                        LastName = item["lastname"].ToString(),
                        shortimagepath = item["imageshortpath"].ToString(),
                        // I am struggling here to bind address column to list of address
                        cityid  = addresses.Where(t => t.id == idObj)
                                 .Select(t=>t.peopleaddress.ToString()).ToList()
                    });
 
    }
