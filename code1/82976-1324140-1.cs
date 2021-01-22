    public abstract class MyBaseClass
    {
        protected string _status;
        public virtual string Status
        {
            get { return _status; }
            set { _status = value; } 
        }
    }
    
    public class MySpecificClass : MyBaseClass
    {
        public override string Status
        {
            get
            {
                if(_status == "something")
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
