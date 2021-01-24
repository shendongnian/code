    //you can put this anywhere you want
    public interface IAuditableEntity
    {
        //helper interface. put it on the entities you want to trace.
        string created_by {get;set;}
        DateTime created_time {get;set;}
        
        //todo: add more properties like 'modified'
    }
