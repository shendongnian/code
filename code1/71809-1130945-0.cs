    public class SaveMe { 
       public string Key {get;set}
       public string Value {get;set;}
       public int Id {get;set;}
       public string Name {get;set;}
       public int dAreasID {get;set;}
       public string dAreasIDName {get;set;}
    }
    
      var commonRAR = (from c in dCountries
                       join r in dRegions on c.Key equals r.CountryCd
                       join a in dAreas on r.Id equals a.RegionId
                       select new SaveMe {
                          Key= c.Key, 
                          Value = c.Value, 
                          Id = r.Id, 
                          Name = r.Name, 
                          dAreasID = a.Id, 
                          dAreasIDName = a.Name
                        }
                      );
    
    
      HttpContext.Current.Application["commonData"] = commonRAR;
