    public struct Identifier {
    
       private int? presistanceID;
    
       public Identifier(int presistanceID){
         presistanceID = presistanceID;
       }
    
       public bool IsSetted {
         get {presistanceID.hasvalue};
       }
    }
    
    if (book.BookID.IsSetted){
    }
    
    book.BookID.ToString();
