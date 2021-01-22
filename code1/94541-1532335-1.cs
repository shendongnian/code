    public class HttpSessionedObject : ISessionableObject
    {
        public MyData Data {
            get { return Session["mydata"]; }
            set { Session["mydata"] = value; }
        }
    }
    
    public class DictionaryObject : ISessionableObject
    {
        private readonly Dictionary<string, MyData> _dict = 
                                        new Dictionary<string, MyData>();
    
        public MyData Data {
            get { return dict ["mydata"]; }
            set { dict ["mydata"] = value; }
        }
    }
