            //examble object
            class Person
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
            }
            // the value which you want to get from datagridview
            private Person _selectedValue;
            // the datagridview datasource, which you neet to set 
            private IEnumerable<Person> _gridDataSource = 
                new List<Person>()
                    {
                        new Person {FirstName="Bob",LastName="Smith" },
                        new Person {FirstName="Joe",LastName="Doe"}
                    };
    
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if(e.KeyCode== Keys.F3)
                {
                    var btnOk = new Button() { Text = "Ok", Anchor= AnchorStyles.None };
                    var btnCancel = new Button() { Text = "Cancel",Anchor= AnchorStyles.Right };
    
                    var dg = new DataGridView();
                    var bs = new BindingSource();
                    bs.DataSource = _gridDataSource;
                    dg.DataSource = bs;
                    dg.Dock = DockStyle.Fill;
                    dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    
                    //setup a layout wich will nicely fit to the window
                    var layout = new TableLayoutPanel();
                    layout.Controls.Add(dg, 0, 0);
                    layout.SetColumnSpan(dg, 2);
                    layout.Controls.Add(btnCancel, 0, 1);
                    layout.Controls.Add(btnOk, 1, 1);
                    layout.RowStyles.Add(new RowStyle(SizeType.Percent));
                    layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                    layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    layout.Dock = DockStyle.Fill;
    
                    //create a new window and add the cotnrols
                    var window = new Form();
                    window.StartPosition = FormStartPosition.CenterScreen;
                    window.Controls.Add(layout);
    
    
                    // set the ok and cancel buttons of the window
                    window.AcceptButton = btnOk;
                    window.CancelButton = btnCancel;
                    btnOk.Click += (s, ev) => { window.DialogResult = DialogResult.OK; };
                    btnCancel.Click += (s, ev) => { window.DialogResult = DialogResult.Cancel; };
    
                    //here we show the window as a dialog
                    if (window.ShowDialog() == DialogResult.OK)
                    {
                            _selectedValue =(Person) bs.Current;
                            MessageBox.Show(_selectedValue.FirstName);
                    }
                }
    }
