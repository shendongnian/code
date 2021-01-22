    public class MyForm : Form
    {
      private delegate void UpdateControlTextCallback(Control control, string text);
      public void UpdateControlText(Control control, string text)
      {
        if (control.InvokeRequired)
        {
          control.Invoke(new UpdateControlTextCallback(UpdateControlText), control, text);
        }
        else
        {
          control.Text = text;
        }
      }
    }
