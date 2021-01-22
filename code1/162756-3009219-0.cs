    using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using System.Data.SqlClient;
	namespace CSCellFormat
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			DataTable dt = new DataTable();
			private void Form1_Load(object sender, EventArgs e)
			{
				String strConn = "Server = .;Database = AdventureWorks; Integrated Security = SSPI;";
				SqlConnection conn = new SqlConnection(strConn);
				SqlDataAdapter da = new SqlDataAdapter("Select * from HumanResources.Employee", conn);
				da.Fill(dt);
				dataGridView1.DataSource = dt;
			}
			private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
			{
				DataRowView drv;
				if (e.RowIndex >= 0)
				{
					drv = dt.DefaultView[e.RowIndex];
					Color c;
					if (drv["Gender"].ToString() == "M")
					{
						c = Color.LightBlue;
					}
					else
					{
						c = Color.Pink;
					}
					e.CellStyle.BackColor = c;
				}
			}
		}
	}
