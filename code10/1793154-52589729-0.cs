    public string deleteClick(String ID)
        {
            Session["ID"] = Request.Params["ID"];
            var id = "";
            id = Session["ID"].ToString();
    
            DialogResult myResult;
            myResult = MessageBox.Show("Are you sure?", "Delete Confirmation", 
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
    
            if (myResult == DialogResult.OK)
            {
                  errorbox.Visible = false;
                //connect to database and delete
                return "true"; //if successful
            }
            return "false"; //if not successful
       }
