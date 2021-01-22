    class BaseDocument
    {
        public DocPath{get; set;}
        public virtual DocContent{get; set;}
    } 
    
    class DerviedDocument: BaseDocument
    {
        public override DocContent 
        { 
            get { throw new NotImplementedException("Do not use this property!"); }
            set { } 
        }    
    }
