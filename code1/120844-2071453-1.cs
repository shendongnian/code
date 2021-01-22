    #define "Show" 
    
    
      public void TargetMethod()
        {
          //Code
        }
       [ Conditional("Hidden")]
       public void HiddenMethod()
        {
           TargetMethod()
        }
     [ Conditional("Show")]
      public void AllowMethod()
        {
           TargetMethod()
        }
