    class ResolvedBy
    {
        string link;
    string value;
        public string Link
        {
            get
            {
                return this.link;
            }
            set
            {
                this.link= value ==null ? "" : value;
            }
        }
     public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                
    this.value = value ==null ? "" : value;
            }
        }
    
    }
