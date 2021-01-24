    public class MyEntityServiceModel
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
    
    // this looks differently in recent versions of AutoMapper, but you get the idea
    Mapper.CreateMap<MyEntityServiceModel, MyEntity>();
    
    // your update functions looks the same, except that it receives a service model, not a data model
    Update(MyEntityServiceModel updatedEntity, int id) 
    {
       // same code here
    }
