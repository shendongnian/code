    public int SomeProperty {
        
       set {
          
          if(designerComplete) {
              throw new IllegalOperationException();
          }
    
       }
    
    }
