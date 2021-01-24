    public class SQLValue<T> : ISQLValue
    { 
        public string nam { get; set; } 
        public string typ { get; set; } 
    
        public T val { get; set; } 
    
        object ISQLValue.val 
        {  
            get { return this.val; }
            set { this.val = (T)value; }
        }
    }
