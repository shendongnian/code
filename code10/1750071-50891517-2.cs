    public class AuditBase
    {
        //Adapt your requirements, the propertys are exists in db
        public datetime creationdate { get; set; }
        public datetime modificationdate { get; set; }
        public string creationuser { get; set; }
        public string modificationuser { get; set; }
    }
    public class ModelBBDD : AuditBase
    { }
