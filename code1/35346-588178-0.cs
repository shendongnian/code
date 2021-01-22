        public Form1()
        {
            InitializeComponent();
            //Create In-Memory DataTable
            DataTable myTable = new DataTable();
            // Add DataColumns to the DataTable.
            DataColumn myNameColumn = new DataColumn("Name");
            myNameColumn.DataType = System.Type.GetType("System.String");
            myNameColumn.DefaultValue = "default string";
            myTable.Columns.Add(myNameColumn);
            DataColumn myValueColumn = new DataColumn("Value");
            myValueColumn.DataType = System.Type.GetType("System.String");
            myValueColumn.DefaultValue = "default string";
            myTable.Columns.Add(myValueColumn);
            //Bind DataTable to dataGrid1
            dgUserAttributes.DataSource = myTable;
                      
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            //tableStyle.MappingName = "MainStyle";
            DataGridTextBoxColumn tbcName = new DataGridTextBoxColumn();
            tbcName.Width = 12; 
            tbcName.MappingName = "Name";
            tbcName.HeaderText = "Name";
            tableStyle.GridColumnStyles.Add(tbcName);
            DataGridTextBoxColumn tbcValue = new DataGridTextBoxColumn();
            tbcValue.Width = 300;
            tbcValue.MappingName = "Value";
            tbcValue.HeaderText = "Value";
            tableStyle.GridColumnStyles.Add(tbcValue);
            // dgUserAttributes is defined as a System.Windows.Forms.DataGrid
            dgUserAttributes.TableStyles.Clear();        
            dgUserAttributes.TableStyles.Add(tableStyle);           
        }
            
  
