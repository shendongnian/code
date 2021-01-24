    Dictionary<string, Label> labels;
    // ...
    labels = new Dictionary<string, Label>();
    for(int o = 2; o > 6; o++)
    {
        string labelName = string.Format("h" + o.ToString() + "a");
        Label label = GetLabel(labelName);
        labels.Add(labelName, label);
    }
    // ...
    private Label GetLabel(string labelName)
    {
        Control[] controls = this.Controls.Find(labelName, true);
        foreach (Control control in controls)
        {
            if (control is Label) // if (control.GetType() == typeof(Label))
            {
               return control as Label;
            }
        }
        return null;
    }
