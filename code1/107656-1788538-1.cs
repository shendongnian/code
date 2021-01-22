    private void button1_Click(object sender, EventArgs e)
    {
        Dictionary<string, bool> checkBoxes = new Dictionary<string, bool>();
        LoopControls(checkBoxes, this.Controls);
    }
    private void LoopControls(Dictionary<string, bool> checkBoxes, Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control is CheckBox)
                checkBoxes.Add(control.Name, ((CheckBox) control).Checked);
            if (control.Controls.Count > 0)
                LoopControls(checkBoxes, control.Controls);
        }
    }
