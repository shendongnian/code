    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.OleDb;
    namespace StockCharts
    {
    public partial class Form1 : Form
    {
        System.Data.DataSet DtSet = new System.Data.DataSet();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database.Stocks' table. You can move, or remove it, as needed.
            // this.stocksTableAdapter.Fill(this.database.Stocks);
            LoadData();
        }
        private void LoadData()
    {
        try {
                System.Data.OleDb.OleDbConnection MyConnection;
                // System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textselect.Text + "; Extended Properties = Excel 8.0");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + textchoice.Text + "$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "TestTable");
                // DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                dataGridView.DataSource = DtSet.Tables[0];
                MyConnection.Close();
            }
            catch (Exception ex)
            {
             MessageBox.Show(ex.ToString());
            }
    }       
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                stocksBindingSource.EndEdit();
                stocksTableAdapter.Update(database.Stocks);
                Refresh();
                MessageBox.Show("Your data has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //Clear Grid
            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            //
            chart.Series["Daily"].XValueMember = "Day";
            chart.Series["Daily"].YValueMembers = "High,Low,Open,Close";
            chart.Series["Daily"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            chart.Series["Daily"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";
            //chart.Series["Daily"]["OpenCloseStyle"] = "Triangle";
            chart.Series["Daily"]["ShowOpenClose"] = "Both";
            chart.DataManipulator.IsStartFromFirst = true;
            //chart.DataSource = database.Stocks;
            chart.DataSource = DtSet.Tables[0];
            chart.DataBind();
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void chart_Click(object sender, EventArgs e)
        {
        }
        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            if (opfd.ShowDialog() == DialogResult.OK)
                textselect.Text = opfd.FileName;
        }
        private void showdata_Click(object sender, EventArgs e)
        {
            try {
                System.Data.OleDb.OleDbConnection MyConnection;
               // System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textselect.Text + "; Extended Properties = Excel 8.0");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + textchoice.Text + "$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "TestTable");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                dataGridView.DataSource = DtSet.Tables[0];
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        //
        }
    }
    }
