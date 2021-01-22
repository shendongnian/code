    public void DoSomething(Control.ControlCollection controls)
    {
        foreach (Control ctrl in controls)
        {
            // do something to ctrl
            MessageBox.Show(ctrl.Name);
            // recurse through all child controls
            DoSomething(ctrl.Controls);
        }
    }
