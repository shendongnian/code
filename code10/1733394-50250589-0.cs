    public partial class GridManualBind : Form
    {
        //Binding Source for datagridView
        BindingSource datasource = new BindingSource();
        //Binding Source for datagridView Combobox Column
        BindingSource reportLookupBinding = new BindingSource();
        List<ManualData> list = new List<ManualData>();
        public GridManualBind()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            datasource.DataSource = typeof(ManualData);
            reportLookupBinding.DataSource = typeof(ManualDataReport);
            dataGridView1.DataSource = datasource;
            // column
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price Type",
                DataPropertyName = "PriceType"
            });
            // As you see in the picture its configured for combo box column
            dataGridView1.Columns.Add(new DataGridViewComboBoxColumn
            {
                HeaderText = "Report Code Lookup",
                DataPropertyName = "ReportCodeLookup",
                DataSource = reportLookupBinding,
                DisplayMember = "Short_Description",
                ValueMember = "Report_Code"
            });
            //Adding Data for Combo Box data Source
            reportLookupBinding.Add(new ManualDataReport { Report_Code = 0, Short_Description = "0-Reg" });
            reportLookupBinding.Add(new ManualDataReport { Report_Code = 1, Short_Description = "1-Post" });
            list.AddRange(new ManualData[]
            {
                 new ManualData { PriceType="Reg", ReportCodeLookup=0 },
                 new ManualData { PriceType="Post", ReportCodeLookup=1 }
            });
            //Adding Data for grid View data Source
            datasource.Add(list[0]);
            datasource.Add(list[1]);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // you can Set the combo box value using this;
            list[0].ReportCodeLookup = 1;
            dataGridView1.Invalidate();
        }
        private class ManualData
        {
            public string PriceType { get; set; }
            public int ReportCodeLookup { get; set; }
        }
        private class ManualDataReport
        {
            public int Report_Code { get; set; }
            public string Short_Description { get; set; }
        }
    }
