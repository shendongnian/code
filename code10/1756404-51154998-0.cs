    public class HouseList{
        public string Code {get;set;}
        public string Message {get;set;}
       public List<House> Data {get;set;}
    }
    var houseList = JsonConvert.DeserializeObject<HouseList>(json).data; 
