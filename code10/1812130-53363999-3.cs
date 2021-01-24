    public partial class FirstForm : Form
    {
        private SecondForm sf; //Declaring it so it is accessible from whole first form class
        private int lastSelectedRow = -1; //Will use it later
        public FirstForm()
        {
            //All your code
        }
        private void dataGridView_CellClick(object sender, EventArgs e)
        {
            //This event fires every time user click cell
            if(sf == null)
            {
                //This means our second form has not been initialized so maybe show message to user and return or open it up
                //First solution
                sf = new SecondForm();
                sf.Show();
                //Second solution
                MessageBox.Show("Second form is not initialized!");
                return;
            }
            //I would here check if(sf.Visible) and if it is not i would sf.Show();
            //We check if same row has been selected. If it does then we do nothing
            if(dataGridView.SelectedRows[0].Index == lastSelectedRow)
                return;
            int uid = Convert.ToInt32(row.Cells["ColumnThatContainsUserId"].Value);
            string uname = row.Cells["ColumnThatContainsUserName"].Value.ToString();
           sf.SwitchUser(uid, uname); //Accessing through global variable
           lastSelectedRow = dataGridView.SelectedRows[0].Index;
        }
    }
