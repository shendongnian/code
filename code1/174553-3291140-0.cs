    class SonyTelevision: ITelevision {
      public void TogglePower {
        //Perform the operation to turn the TV on or off
      }
      public void ChangeChannel (Int32 channel) {
        // Perform the operation of changing the channel
      }
    }
    class ToshibaTelevision: ITelevision {
      public void TogglePower {
        //Perform the operation to turn the TV on or off
      }
      public void ChangeChannel (Int32 channel) {
        // Perform the operation of changing the channel
      }
    }
    class Remote {
      private _television : Object; // here we don't care what kind of TV it is.
    
      public void ToggleTvPower {
        ITelevision tv = _television as ITelevision;
        tv.TogglePower();
      }
    }
