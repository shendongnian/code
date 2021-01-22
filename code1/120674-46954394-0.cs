    public class DraggableControl : UserControl
    {
      private Point? _initialMousePosition;
      public DraggableControl()
      {
        PreviewMouseDown += OnPreviewMouseDown;
      }
      private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e) {
        _initialMousePosition = e.GetPosition(this);
      }
