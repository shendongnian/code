    public void TheGuiInvokeMethod(Control source, string text)
    {
       if (InvokeRequired)
          Invoke(new Action<Control, string>(TheGuiInvokeMethod, source, text);
       else
       {
           // it is safe to update the GUI using the control
          control.Text = text;
       }
    }
