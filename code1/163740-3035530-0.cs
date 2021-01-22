    public class TabControlIgnoresCtrlTab : TabControl
    {
      protected override void OnKeyDown(KeyEventArgs e)
      {
        if(e.Key == Key.Tab) return;
        base.OnKeyDown(e);
      }
    }
