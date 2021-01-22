    class Start
    {
      M1() 
      {
    
      }
    }
    
    class Stop
    {
      M2()
      { 
    
      }
    }
    
    public class PreferencesReaderBase : IPreferencesReader
    {
      private Start start = new Start();
      private Stop stop = new Stop()
      public void M1()
      {
          this.start.M1();
      }
    
    
      public void M2()
      {
          this.stop.M2();
      }
    }
