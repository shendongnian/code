    class BaseDocument
    {
        public DocPath{get; set;}
        public virtual DocContent{get; set;}
    } 
    
    class DerviedDocument: BaseDocument
    {
        public override DocContent 
        { 
            get { return null; }
            set { } 
        }    
    }
