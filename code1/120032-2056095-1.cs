    MyDataSouce dataSource = new MyDataSouce();
    foreach (Control ctl in this.Controls) {
        ctl.DataBindings.Add(new Binding("Enabled", dataSource, "Enabled"));
        ctl.DataBindings.Add(new Binding("Visible", dataSource, "Visible"));
    }
