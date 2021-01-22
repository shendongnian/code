    public class MyTabPage : TabPage
    {
      private const int WM_MOUSEWHEEL = 0x20a;
      protected override void WndProc(ref Message m)
      {
        // ignore WM_MOUSEWHEEL events
        if (m.Msg == WM_MOUSEWHEEL)
        {
          return;
        }
        base.WndProc(ref m);
      }
    }
