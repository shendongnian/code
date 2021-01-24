    class ResolvedBy
    {
        string link;
    string value;
        public string Link
        {
            get
            {
                return (this.link == null ? "" :this.link 
            }
            set
            {
                this.link= (value ==null ? "" : value);
            }
        }
     public string Value
        {
            get
            {
                return (this.value == null ? "" : this.value); 
            }
            set
            {
                
    this.value =( value == null ? "" : value);
            }
        }
    
    }
