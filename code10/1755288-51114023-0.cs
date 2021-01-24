    using System;
    using System.Data;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                var dataSet = GetDataFromServer();
    
                dataSet.Relations.Clear();
                dataSet.Relations.Add("OrderDetails",
                    dataSet.Tables["Table1"].Columns["Bon"],
                    dataSet.Tables["Table2"].Columns["Bon"]);
    
                gridControl1.DataSource = dataSet.Tables["Table1"];
            }
    
            private static DataSet GetDataFromServer()
            {
                var dataSet = new DataSet();
                var table1 = new DataTable("Table1");
                table1.Columns.Add("Bon", typeof(int));
                table1.Columns.Add("Other", typeof(string));
                var row1 = table1.NewRow();
                row1["Bon"] = 1;
                row1["Other"] = "Bon 1";
                table1.Rows.Add(row1);
    
                var row2 = table1.NewRow();
                row2["Bon"] = 2;
                row2["Other"] = "Bon 2";
                table1.Rows.Add(row2);
    
                var table2 = new DataTable("Table2");
                table2.Columns.Add("Id", typeof(int));
                table2.Columns.Add("Other2", typeof(string));
                table2.Columns.Add("Bon", typeof(int));
    
                var row3 = table2.NewRow();
                row3["Id"] = 1;
                row3["Other2"] = "Bon Other 1";
                row3["Bon"] = 1;
                table2.Rows.Add(row3);
    
                var row4 = table2.NewRow();
                row4["Id"] = 2;
                row4["Other2"] = "Bon Other 2";
                row4["Bon"] = 1;
                table2.Rows.Add(row4);
    
                var row5 = table2.NewRow();
                row5["Id"] = 3;
                row5["Other2"] = "Bon Other 3";
                row5["Bon"] = 2;
                table2.Rows.Add(row5);
    
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                return dataSet;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var ds = GetDataFromServer();
                var row5 = ds.Tables["Table2"].NewRow();
    
                row5["Id"] = ds.Tables["Table2"].Rows.Count + 1;
                row5["Other2"] = "Bon Other " + ds.Tables["Table2"].Rows.Count + 1;
                row5["Bon"] = 2;
    
                ds.Tables["Table2"].Rows.Add(row5);
                ds.Relations.Clear();
                ds.Relations.Add("OrderDetails",
                    ds.Tables["Table1"].Columns["Bon"],
                    ds.Tables["Table2"].Columns["Bon"]);
    
                gridControl1.DataSource = ds.Tables["Table1"];
                gridControl1.RefreshDataSource();
            }
        }
    }
