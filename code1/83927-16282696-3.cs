    class BaseDocument
    {
        public string DocPath{get; set;}
        public string DocContent{get; set;}
    } 
    
    class DerviedDocument: BaseDocument
    {
       //this class should not get the DocContent property
        
      [Browsable(false), EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
      public new string DocContent{ get; set; }
    
      public Test()
      {
         DerivedDocument d = new DerivedDocument();
         d.//intellisense will only show me DocPath
         //I do not want this class to see the DocContent property
      }
    }
