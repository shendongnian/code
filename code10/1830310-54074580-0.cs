    //public property to retrieve pelerins
    public List <MapPdf> pls new List<MapPdf>();
     ...
     ...
    public static void Create(List<MapPdf> pps, Saison s, Agence agence)
    {    
     foreach (var pelerins in grouped)
     {
            if (string.IsNullOrEmpty(pelerins.Key) || pelerins.Count() <= 0)
                break;
            if (writer.PageEvent == null)
            {
               //do logic
               ...
               //store the one you are interested in, so you can use it later on
               pls = pelerins.ToList(); 
            }
             
    
     }
    }
            
