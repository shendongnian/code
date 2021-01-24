    public class MyGame {
       public MyGame(ILoader loader, ...) {
          _loader = loader;
       }
    
       public Load(int saveSlotNumber) {
           _data = _loader.Load(saveSlotNumber);        
       }
    }
