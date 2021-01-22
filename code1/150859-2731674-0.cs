    public class DragDropInfo
    {
      public DragDropBaseControl Control { get; private set; }
    
      public DragDropInfo(DragDropBaseControl control)
      {
        this.Control = control;
      }
    }
