    class Life
    {
    
        //Properties
        public string Person { get; set; }
        public string Partner { get; set; }
    
        public Life()
        {
            this.Person = "Dave";
            this.Partner = "Sarah";
    
            MessageBox.Show("Life Constructor Called");
        }
    }
