    public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			// data column to filter against
			string[] list = new string[4];
			list[0] = "Name";
			list[1] = "CustomerAccountNo";
			list[2] = "Telephone";
			list[3] = "Postal";
			cboColumn.DataSource = list;
			cboColumn.SelectedIndex = 0;
			
			// left, right or middle search
			string[] list2 = new string[3];
			list2[0] = "Contains";
			list2[1] = "StartsWith";
			list2[2] = "EndsWith";
			cboFilterAtt.DataSource = list2;
			cboFilterAtt.SelectedIndex = 0;
		}
		
		private void btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor; 
				CustomerSearchDataContext db = new CustomerSearchDataContext();
				//string condition = string.Format("{0}.{1}({2})", cboColumn.SelectedValue, cboFilterAtt.SelectedValue, txtSearch.Text);
				string condition = string.Format("{0}.{1}({2})", cboColumn.SelectedValue, cboFilterAtt.SelectedValue, "\"" + txtSearch.Text + "\"");
				MessageBox.Show(condition);
				var customerQuery = db.vCustomers.Where(condition).OrderBy("CustomerAccountNo");
				customerBindingSource.DataSource = customerQuery;
				dataGridView1.DataSource = customerBindingSource;
				dataGridView1.Columns["CustomerId"].Visible = false;
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				MessageBox.Show("An Error Occured - " + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor.Current = Cursors.Default; 
			}
		}
	}
