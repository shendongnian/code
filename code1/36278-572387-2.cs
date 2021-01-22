    using System.Windows.Forms;
    
    public class ControlExtensions
    {
      public void Reset(this Control control)
      {
        if (control.Tag != null)
        {
          if (control is TextBoxBase && control.Tag is string)
          {
            control.Text = control.Tag as string;
          }
          else if (control is CheckBox && control.Tag is bool)
          {
            control.Checked = control.Tag as bool;
          }
          // etc
        }
        
        foreach (Control child in control.Children)
          child.Reset();
      }
    }
