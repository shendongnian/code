    public class Protocol_common : IProtocol 
    { 
      MyInterfaceMethod1() 
      { 
         Same1(); 
         DiffStuff(); 
         Same2(); 
      } 
    
      abstract void DiffStuff();
      
    }
    
    public class Protocol1 : IProtocol 
    { 
      DiffStuff() 
      { 
          /// stuff here.
      } 
    }
    
    public class Protocol2 : IProtocol 
    { 
      DiffStuff() 
      { 
          /// nothing here.
      } 
    }
