    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApp4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
                //Left = (MdiParent.ClientRectangle.Width - Width) / 2;
                //Top = (MdiParent.ClientRectangle.Height - Height) / 2;
    
                DataGridViewTextBoxColumn dgvslno = new DataGridViewTextBoxColumn();
                dgvslno.HeaderText = "Item Code";
                dgvslno.Width = 40;
                dataGridView1.Columns.Add(dgvslno);
    
                DataGridViewTextBoxColumn dgvpro = new DataGridViewTextBoxColumn();
                dgvpro.HeaderText = "Product Name";
                dgvpro.Width = 40;
                dataGridView1.Columns.Add(dgvpro);
            }
    
            public AutoCompleteStringCollection AutoCompleteLoad()
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MEDIXPC197;Initial Catalog=Inventory;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Select ProductCode from tblmaster", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    mycoll.Add(dr["ProductCode"].ToString());
                }
                return mycoll;
            }
    
            private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                int column = dataGridView1.CurrentCell.ColumnIndex;
                string headerText = dataGridView1.Columns[column].HeaderText;
    
                if (headerText.Equals("Item Code"))
                {
                    TextBox tb = e.Control as TextBox;
    
                    if(tb != null)
                    {
                        tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        tb.AutoCompleteCustomSource = AutoCompleteLoad();
                        tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb !=null)
                    {
                        tb.AutoCompleteMode = AutoCompleteMode.None;
                    }
                }
            }
        }
    }
