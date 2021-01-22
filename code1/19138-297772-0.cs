    public void ClearControl(Control control)
    {
      TextBox tb = control as TextBox;
      if (tb != null)
      {
        tb.Text = String.Empty;
      }
      // repeat for combobox, listbox, checkbox and any other controls you want to clear
      if (control.HasChildren)
      {
        foreach(Control child in control.Controls)
        {
          ClearControl(child)
        }
      }
    }
