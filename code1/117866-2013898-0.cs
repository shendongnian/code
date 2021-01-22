    class Logger { 
       static public void OutputLog (object someObj) {
          ...
       }
    }
    
    class SomeClass { 
       private void SomeMethod () { 
          Logger.OutputLog (this);
       } 
    }
