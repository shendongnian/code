    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            private List<DataPoint> pts = new List<DataPoint>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                InsertPoint(10, 20);
                InsertPoint(12, 40);
                InsertPoint(16, 60);
                InsertPoint(20, 77);
                InsertPoint(92, 80);
    
                MakeGrid();
            }
    
            public void InsertPoint(int parameterValue, int commandValue)
            {
                DataPoint pt = new DataPoint();
                pt.XValue = commandValue;
                pt.YValues[0] = parameterValue;
                pts.Add(pt);
            }
    
            private void MakeGrid()
            {
                dgv1.SuspendLayout();
                DataTable dt = new DataTable();
                dt.Columns.Clear();
                dt.Columns.Add("Parameter");
                dt.Columns.Add("Command");
    
                //*** Add Data to DataTable
                for (int i = 0; i <= pts.Count - 1; i++)
                {
                    dt.Rows.Add(pts[i].XValue, pts[i].YValues[0]);
                }
                dgv1.DataSource = dt;
    
                //*** Formatting for the grid is performed in event dgv1_DataBindingComplete.
                //*** If its performed here, the changes appear to get wiped in the grid control.
            }
    
            private void dgv1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Alignment = DataGridViewContentAlignment.MiddleRight;
    
                //*** Add row number to each row
                foreach (DataGridViewRow row in dgv1.Rows)
                {
                    row.HeaderCell.Value = (row.Index + 1).ToString();
                    row.HeaderCell.Style = style;
                    row.Resizable = DataGridViewTriState.False;
                }
                dgv1.ClearSelection();
                dgv1.CurrentCell = null;
                dgv1.ResumeLayout();
            }
        }
    }
