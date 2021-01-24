        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindData();
            }
        }
        private void BindData()
        {
               string[] myArray = {"a","b","c"};
                foreach (string item in myArray)
	            {
		            chkUsers.Items.Add(item);
	            }
                chkUsers.Items[1].Selected = true;
        }
        protected void SumitButton_Click(object sender, EventArgs e)
        {
            var x = chkUsers.SelectedItem;
            Response.Write(x);
        }
