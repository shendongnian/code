    public class Start1
    {
      public EventHandler FrameAcquired
      {
        add 
        {
          this.camera.FrameAcquired += value;
        }
        remove
        {
          this.camera.FrameAcquired -= value;
        }
    }
