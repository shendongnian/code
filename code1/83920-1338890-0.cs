    public interface IDoc
    {
       DocPath{get;set;}
    }
    
    class BaseDocument : IDoc
    {
         public DocPath{get; set;}
         public DocContent{get; set;}
    } 
    
    class DerviedDocument
    {
        public DerivedDocument(IDoc doc)
        {
            this.Doc = doc;
        }
    
        public IDoc Doc{get;set;}
        
         public Test()
         {
            DerivedDocument d = new DerivedDocument(new BaseDocument());
            d.//here you will only see d.IDoc which only exposes DocPath
              
         }
    }
