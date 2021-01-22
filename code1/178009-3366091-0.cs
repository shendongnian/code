    public GetMemberByName(MyObject myobj, string name)  
    {  
      return myobj.GetProperty(name);
    }
    
    public class MyObject
    {
        private Dictionary<string, object> m_Properties = new Dictionary<string, object>();
    
        public object GetProperty(string name)
        {
            return m_Properties[name];
        }
    
        public void SetProperty(string name, object value)
        {
            m_Properties[name] = value;
        }
    
        public object Prop1
        {
            get { return GetProperty("PropOne"); }
            set { SetProperty("PropOne", value); }
        }
    
        public object Prop2
        {
            get { return GetProperty("PropTwo"); }
            set { SetProperty("PropTwo", value); }
        }
    }
