    List<Control> ControlList = new List<Control>();
    private void GetAllControls(Control container)
    {
        foreach (Control c in container.Controls)
        {
            GetAllControls(c);
            if (c is TextBox) ControlList.Add(c);
        }
    }
