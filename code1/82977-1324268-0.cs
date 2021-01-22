    public abstract class MyBaseClass
    {
        public abstract string Status { get; set; }
    }
    public class MySpecificClass : MyBaseClass
    {
       private string _status;
       public override string Status
       {
           get
           {
              if(this._status == "something")
                return "some status";
              else
                return "some other status";
           }
           set
           {
               _status = value;
           }
       }
    }
