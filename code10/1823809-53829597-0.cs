    IDataReader reader = base.DataBase.ExecuteReader(cmd);
    var dsList = new List<IHumanReadableData>();
    dsList = _humanReadableDataObjectMapper.MapList(reader);
    
    dsList.Select(r => { 
             r.PersonName = SqlFunctions.Checksum(r.PersonName).ToString(); 
                        });
   
