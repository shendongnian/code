    //.cs
    protected void valQty_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //repeat validation logic on the server
    }
    //extra: Call OnCommand handler instead of OnClick
    //Here you can use e.CommandArgument unavailable in OnClick handler
    protected void Quantity_Update_Command(object sender, CommandEventArgs e)
    {
        //update product using e.CommandArgument
    }
