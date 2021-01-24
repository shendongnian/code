	public partial class Form1 : Form
	{
		UserinfoEntities conn = new UserinfoEntities();
		int selectedUserInfoID; // Keep the currently selected ID of the tableUserinfo object
		public Form1()
		{
			InitializeComponent();
		}
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Save the clicked cell's ID (assuming it comes from this expression)
			selectedUserInfoID = Convert.ToInt32(dgvData.CurrentRow.Cells["id"].Value.ToString()); 
		}
		public void selectTable()
		{
			dgvData.DataSource=conn.tableUserinfoes.ToList<tableUserinfo>();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			selectTable();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult qustion = MessageBox.Show("Are you Sure to Deleted this Record ","Message Deleted",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
			if (qustion == DialogResult.Yes)
			{
				 // Ask Entity to generate the proper object with the selected ID (has to be PRIMARY KEY in that table)
				tableUserinfo selectedUserInfo = conn.tableUserinfoes.Find(selectedUserInfoID);
				
				if (selectedUserInfo != null)
					conn.tableUserinfoes.Remove(selectedUserInfo); // Tell Entity to delete that object (row from database)
				
				conn.SaveChanges(); // Commit the delete operation
				selectTable();
			}
		}
	}
