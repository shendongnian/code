    public class MyBean : EntityData
    {
        public MyBean() { }
        public string Content { get; set; }
        public bool ShouldSerializeCreatedAt()
        {        
            return false;
            // Or you can add some condition to whether serialize the property or not on runtime 
        }
    }
