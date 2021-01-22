    class scaner
    {
        readonly IEnumerable<ListBox> listBoxes;
    
        public IEnumerable<ListBox> ListBoxes
        {
            get { return this.listBoxes; }
        }
    
        public scaner(params ListBox[] listBoxes)
        {
            this.listBoxes = listBoxes;    
        }
    }
