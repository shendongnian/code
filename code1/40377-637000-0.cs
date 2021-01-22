    abstract class Customer {
        public virtual string Name { get; set; }
    
        public virtual IDictionary<string, object> GetProperties()
        {
            var ret = new Dictionary<string, object>();
            ret["Name"] = Name;
            return ret;
        }
    }
    
    class HighValueCustomer : Customer {
        public virtual int MaxSpending { get; set; }
    
        public override IDictionary<string, object> GetProperties()
        {
            var ret = base.GetProperties();
            ret["Max spending"] = MaxSpending;
            return ret;
        }
    } 
    
    class SpecialCustomer : Customer {
        public virtual string Award { get; set; }
    
        public override IDictionary<string, object> GetProperties()
        {
            var ret = base.GetProperties();
            ret["Award"] = Award;
            return ret;
        }
    }
