    [Serializable]
    public class CrudRequestModel
    {
        public string Prop1 {get; set;} 
        public string Prop2 {get; set;}
        . . . . .
    }
    public class CrudRequestProcessor
    {
        public CrudRequestProcessor(CrudRequestModel m) {. . . }
        
        public bool Persist()
        {
            // code that will execute DB call
        }
        public bool SaveQueue(QueueConfig conf)
        {
            // code that will serialize and save model to file or whatever if DB call fails
        }
    }
