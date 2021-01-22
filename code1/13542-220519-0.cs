    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Reflection;
    using System.Threading;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private delegate void PROG_Delegate<TGridLine>(Control dgv, IEnumerable<TGridLine> gridLines, string[] columns);
            public static void PopulateReadOnlyGrid<TGridLine>(Control dgv, IEnumerable<TGridLine> gridLines, string[] columns)
            {
                if (dgv.InvokeRequired)
                {
                    dgv.BeginInvoke
                                (
                                    new PROG_Delegate<TGridLine>(PopulateReadOnlyGrid<TGridLine>),
                                    new object[] { dgv, gridLines, columns }
                                );
                    return;
                }
                MessageBox.Show("hi");
                //GridUtils.StatePreserver statePreserver = new GridUtils.StatePreserver(dgv);
                //System.Data.DataTable dt = CollectionHelper.ConvertToDataTable<TGridLine>((gridLines));
                //dgv.DataSource = dt;
                //dgv.DataMember = "";
                //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //GridUtils.OrderColumns<TGridLine>(dgv, columns);
                //statePreserver.RestoreState();
                //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                PopulateReadOnlyGrid(this, new int[] { 1, 2, 3 }, new string[] { "a" });
                ThreadPool.QueueUserWorkItem(new WaitCallback((a) =>
                {
                    PopulateReadOnlyGrid(this, new int[] { 1, 2, 3 }, new string[] { "a" });
                }));
            }
        }
    }
