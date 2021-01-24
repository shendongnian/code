    //Setting the ViewState 
        protected void MyGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = MyGridView.SelectedRow;
            ViewState["id"] = row.Cells[3].Text;
        }
     //Assigning the ViewState 
        protected void MyButton_Click(object sender, EventArgs e)
        {
            lable1.Text = ViewState["id"].ToString();
        }
