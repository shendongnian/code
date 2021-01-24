    private List<String> comboSource1;
    private List<String> comboSource2;
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        comboSource1 = new List<string> { "A", "B" };
        comboSource2 = new List<string> { "1", "2" };
        var dt = new DataTable();
        dt.Columns.Add("C1");
        dt.Columns.Add("C2");
        dt.Rows.Add("A", "1");
        dt.Rows.Add("B", "2");
        var c1 = new DataGridViewComboBoxColumn();
        c1.Name = "C1";
        c1.DataPropertyName = "C1";
        c1.DataSource = comboSource1;
        var c2 = new DataGridViewComboBoxColumn();
        c2.Name = "C2";
        c2.DataPropertyName = "C2";
        c2.DataSource = comboSource2;
        dataGridView1.Columns.AddRange(c1, c2);
        this.dataGridView1.DataSource = dt;
        dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
    }
<!---->
    private void dataGridView1_EditingControlShowing(object sender,
        DataGridViewEditingControlShowingEventArgs e)
    {
        var dataGridView = sender as DataGridView;
        if (dataGridView?.CurrentCell?.ColumnIndex != 1) return;
        var comboBox = e.Control as DataGridViewComboBoxEditingControl;
        if (comboBox == null) return;
        comboBox.DropDownStyle = ComboBoxStyle.DropDown;
        if (!true.Equals(comboBox.Tag))
        {
            comboBox.Tag = true;
            comboBox.Validating += (obj, args) =>
            {
                var column = (DataGridViewComboBoxColumn)dataGridView.CurrentCell.OwningColumn;
                var list = comboBox.DataSource as List<string>;
                if (list == null) return;
                var txt = comboBox.Text;
                if (!list.Contains(txt))
                {
                    list.Add(txt);
                    column.DataSource = null;
                    column.DataSource = list;
                }
                dataGridView.CurrentCell.Value = txt;
                dataGridView.NotifyCurrentCellDirty(true);
            };
        }
    }
