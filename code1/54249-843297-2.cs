    class Life
    {
        //Fields
        private string person;
        private string partner;
    
        //Properties
        public string Person
        {
            get { return this.person; }
            set { this.person = value; }
        }
    
        public string Partner
        {
            get { return this.partner; }
            set { this.partner = value; }
        }
    
     
        public Life()
        {
            this.person = "Dave";
            this.partner = "Sarah";
    
            MessageBox.Show("Life Constructor Called");
        }
    }
