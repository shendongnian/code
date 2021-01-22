    abstract class TaskDetail
    {
        public abstract object this[string key] { get; }
    }
    public class FaxDetail : TaskDetail
    {
        public string FaxNumber { get; set; }
        public DateTime DateSent  { get; set; }
        public override object this[string key]
        {
            get
            {
                switch( key )
                {
                    case "FaxNumber": return FaxNumber;
                    case "DateSent":  return DateSent;
                    default:          return null;
                }
            }
        }
    }
    public class EmailDetail : TaskDetail
    {
        public string EmailAddress { get; set; }
        public DateTime DateSent { get; set; }
        
        public override object this[string key]
        {
           get
           {
               switch( key )
               {
                   case "EmailAddress": return EmailAddress;
                   case "DateSent":     return DateSent;
                   default:             return null;
               } 
           }
        }
    }
    // now we can operate against TaskDetails using a KVC approach:
    Task someTask;
    object dateSent = someTask.Detail["DateSent"]; // both fax/email have a DateSent
    if( dateSent != null )
       // ...
