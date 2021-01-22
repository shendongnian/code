    public class ReadOnlyTextBox : TextBox
    {
       const uint WM_SETFOCUS = 0x0007;
    
       public ReadOnlyTextBox()
       {
          this.ReadOnly = true;
          this.BackColor = System.Drawing.SystemColors.Window;
          this.ForeColor = System.Drawing.SystemColors.WindowText;
       }
    
       protected override void WndProc(ref Message m)
       {
          // eat all setfocus messages, pass rest to base
          if (m.Msg != WM_SETFOCUS)
             base.WndProc(ref m);
       }
    }
