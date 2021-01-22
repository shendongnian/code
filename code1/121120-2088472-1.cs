    public class TechnologyView
    {
        public int Id
        {
            get;
            private set;
        }
    
        public string Name
        {
            get;
            private set;
        }
    
        public string Abbreviation
        {
            get;
            private set;
        }
    
        private TechnologyView()
        {
           // Private constructor, required for NH
        }
    
        public TechnologyView( int id, string name, string abbreviation )
        {
           this.Id = id;
           this.Name = name;
           this.Abbreviation = abbreviation;
        }
    }
