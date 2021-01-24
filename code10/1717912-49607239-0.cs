    public class EmployeeWebApiModel
    {
        public int Id { get; set; }
        // other properties
    
        public string Picture { get; set; }
        // byte array to hold HttpPostedFileBase content in Web API context
        public byte[] PicData { get; set; } 
    }
