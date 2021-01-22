    public abstract myBaseClass
    {
     public List<string> MyParameterNames
       {
         get 
             {
                 throw 
                   new ApplicationException("MyParameterNames in base class 
                                     is not hidden by its child.");
             }
       }
    }
