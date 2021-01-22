    public class dummyObject
    {
        public string fake { get; set; }
        public int id { get; set; }
    
        public dummyObject()
        {
            fake = "dummy";
            id = 5;
        }
    
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            sb.Append(id);
            sb.Append(',');
            sb.Append(JSONEncoders.EncodeJsString(fake));
            sb.Append(']');
    
            return sb.ToString();
        }
    }
    
    dummyObject[] dummys = new dummyObject[2];
    dummys[0] = new dummyObject();
    dummys[1] = new dummyObject();
    
    dummys[0].fake = "mike";
    dummys[0].id = 29;
    
    string result = JSONEncoders.EncodeJsObjectArray(dummys);
