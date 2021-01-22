    public abstract class Decoder {
      ...
      abstract void SomeOp();
    } 
    
    public abstract class Decoder<SIGNALTYPE> where SIGNALTYPE : signalType,new() {
    }
    
    Decoder d = new Decoder<SignalOne>();
