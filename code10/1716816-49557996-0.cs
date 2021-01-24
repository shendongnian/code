    var dat = new APIEntity()
                        {
                            unitCodes = new List<int>() { 19215 },
                            start = DateTime.ParseExact("2018-03-12 10:00:00", "yyyy-MM-dd HH:mm:ss", null),
                            end = DateTime.ParseExact("2018-03-12 11:00:00", "yyyy-MM-dd HH:mm:ss", null),                       
                            fields = new DataObject[] {
    							new DataObject { unitCode = "unitCode", timedate  = "timedate " }, // bla, bla
    							new DataObject { unitCode = "unitCode", timedate  = "timedate " }, // bla, bla
    							 // bla, bla
    						}
                          };
