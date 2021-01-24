    public class SomeVM
    {
       public int CustId { get; set; }    
       public int Jan { get;set; }
       public int Feb { get;set; }
       public int Mar { get;set; }
       public int Total { get { return Jan + Feb + Mar;}  }
 
    }
