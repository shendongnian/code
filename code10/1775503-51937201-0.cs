    TxtDateReceived.Text = dt.Rows[0][7].ToString();
    My version:
    if (e.CommandName == "Select")
    {
      Int32 num = Convert.ToInt32(e.CommandArgument); //This just needs to be done once.
        TxtDateReceived.Text = dt.Rows[num].Cells[cell number].Text;
    }
