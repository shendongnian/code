    private IEnumerable<Control> GetAllTextBoxControls(Control container)
    {
        List<Control> controlList = new List<Control>();
        foreach (Control c in container.Controls)
        {
            controlList.AddRange(GetAllTextBoxControls(c));
            if (c is TextBox)
                controlList.Add(c);
        }
        return controlList;
    }
