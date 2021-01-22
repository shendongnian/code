    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //do something when a button is clicked...
        try
        {
            MyBL.TakeAction()
        }
        catch(MyApplicationCustomException ex)
        {
            //display something to the user, etc.
            ltlErrorPane.Text = ex.Message;
        }
    }
