    protected void TxtButton_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                string updatedSNo = (gvr.FindControl("NameId") as Label).Text;
                int SNo = Convert.ToInt32(updatedSNo);
                string updatedText = (gvr.FindControl("altTxtNames") as TextBox).Text;
            }
