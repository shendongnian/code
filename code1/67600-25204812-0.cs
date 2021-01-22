    // return data
    [WebMethod(CacheDuration = 180)]
    public List<latlon> GetData(int id) 
    {
        var data = from p in db.property 
                   where p.id == id 
                   select new latlon
                   {
                       lat = p.lat,
                       lon = p.lon
                       
                   };
        return data.ToList();
    }
    public class latlon
    {
        public string lat { get; set; }
        public string lon { get; set; }
    }
