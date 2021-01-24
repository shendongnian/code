        protected void Page_Load(object sender, EventArgs e)
        {
            //Find the TxtFilter that we want to get the value
            Control cntrlFilter = this.Master.FindControl("TxtCategory");
            if (cntrlFilter != null)
            {
                //Cast the Control instance to TextBox
                TextBox txtFilter = (TextBox)cntrlFilter;
                //Assign the content into the label
                LblContent.Text = txtFilter.Text;
            }
        }
