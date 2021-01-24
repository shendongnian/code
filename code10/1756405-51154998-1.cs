    public class HouseList{
        public class HouseData{
           List<House> Houses {get;set;|
        }
        public string Code {get;set;}
        public string Message {get;set;}
       public HouseData Data {get;set;}
    }
    var houseList = JsonConvert.DeserializeObject<HouseList>(json).Data.Houses; 
