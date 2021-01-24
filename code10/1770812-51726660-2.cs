    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
     {
      //check User Type
       int userType = //Your User Type Here;
       if (userType == 1)
        {
          GridViewID.Columns[15].Visible = false;
        }
       else if (userType == 2 || userType == 3)
        {
         GridViewID.Columns[5].Visible = false;
         GridViewID.Columns[6].Visible = false;
        }                                                                                                                                     
      }
