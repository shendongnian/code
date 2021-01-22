    using System.Diagnostics;
    
    //.... in the method:
    
    if( Debugger.IsAttached) //or if(!Debugger.IsAttached)
    {
      Debugger.Break();
    }
