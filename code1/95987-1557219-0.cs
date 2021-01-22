    protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                RepeaterItem ri = b.Parent as RepeaterItem;
                if (ri != null)
                {
                    string name = null;
    
                    //Fetch data
                    TextBox txtName = ri.FindControl("txtName") as TextBox;
