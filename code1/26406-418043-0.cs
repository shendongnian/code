    public static void EnableTab(TabPage page, bool enable) {
      EnableControls(page.Controls, enable);
    }
    private static void EnableControls(Control.ControlCollection ctls, bool enable) {
      foreach (Control ctl in ctls) {
        ctl.Enabled = enable;
        EnableControls(ctl.Controls, enable);
      }
    }
