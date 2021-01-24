    public class Fields
    {
        public string SerialNumber { get; set; }
        public string id { get; set; }
        public override string ToString() 
        {  
            return this.SerialNumber; // so that we can just bind to the object and get serial number in the ui. 
        }
    }  
