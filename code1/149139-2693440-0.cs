    class MyBackEndClass
    {
        public event EventHandler DataChanged;
    
        private string data = string.Empty;
    
        public string Data
        {
            get { return this.data; }
            set
            {   
                // Check if data has actually changed         
                if (this.data != value)
                {
                    this.data = value;
                    //Fire the DataChanged event
                }
            }
        }
    }
