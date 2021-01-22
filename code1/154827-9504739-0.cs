    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace PagedDataGridView
    {
        public partial class Form1 : Form
        {
            private const int totalRecords = 43;
            private const int pageSize = 10;
            public Form1()
            {
                InitializeComponent();
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Index" });
                bindingNavigator1.BindingSource = bindingSource1;
                bindingSource1.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
                bindingSource1.DataSource = new PageOffsetList();
            }
            private void bindingSource1_CurrentChanged(object sender, EventArgs e)
            {
                // The desired page has changed, so fetch the page of records using the "Current" offset 
                int offset = (int)bindingSource1.Current;
                var records = new List<Record>();
                for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
                    records.Add(new Record { Index = i });
                dataGridView1.DataSource = records;
            }
            class Record
            {
                public int Index { get; set; }
            }
            class PageOffsetList : System.ComponentModel.IListSource
            {
                public bool ContainsListCollection { get; protected set; }
                public System.Collections.IList GetList()
                {
                    // Return a list of page offsets based on "totalRecords" and "pageSize"
                    var pageOffsets = new List<int>();
                    for (int offset = 0; offset < totalRecords; offset += pageSize)
                        pageOffsets.Add(offset);
                    return pageOffsets;
                }
            }
        }
    }
