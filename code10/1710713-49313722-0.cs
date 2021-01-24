    static void Main(string[] args)
    {
      string docNo = string.Empty;
      SaveDocument(out docNo, new ReciptUpdate() { });
    }
     public static bool SaveDocument(out string newDocumentNo, ReciptUpdate reciptUpdate)
    {
       newDocumentNo = "MB120055";
       return true;
    }
    
 
