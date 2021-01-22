    class ControlWrapper
    {
      public Control Control { get; private set; }
      public ControlWrapper(Control control) { Control = control; }
    }
    control.DoDragDrop(new ControlWrapper(new Label()), DragDropEffects.Move);
    
    e.Data.GetDataPresent(typeof(ControlWrapper)) // = true
