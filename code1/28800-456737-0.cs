    public abstract class DocumentGenerator
    {
      abstract protected void AddHeader();
      abstract protected void AddBody();
      abstract protected void AddFooter();
    
      // Template Method http://en.wikipedia.org/wiki/Template_method_pattern
      public FileInfo Generate(string sFileName)
      {
        FileInfo f = null;  
        //create file
        
        // either pass in the file to the below methods or use member vars + an additional write step 
        AddHeader();
        AddBody();
        AddFooter();
        
        // write out everything to the file
        return f;
      }
    }
