    public class CustomSlider : Slider
    {
      public override void OnPreviewMouseMove(MouseEventArgs e)
      {
        if(e.LeftButton == MouseButtonState.Pressed)
          OnPreviewMouseLeftButtonDown(e);
      }
    }
