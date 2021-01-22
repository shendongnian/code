    public abstract class Protocol_common : IProtocol 
    { 
      MyInterfaceMethod1() 
      { 
         Same1(); 
         DiffStuff(); 
         Same2(); 
      } 
    
      abstract void DiffStuff();
      
    }
    
    public class Protocol1 : Protocol_common
    { 
      DiffStuff() 
      { 
          /// stuff here.
      } 
    }
    
    public class Protocol2 : Protocol_common
    { 
      DiffStuff() 
      { 
          /// nothing here.
      } 
    }
