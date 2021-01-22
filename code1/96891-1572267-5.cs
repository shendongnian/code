    protected void GeneralEventHandler(object sender, EventArgs e)
    {
        try 
        {
            Button btn = (Button) sender;
            // if we get this far, it's a button
        }
        catch(InvalidCastException ice)
        {
            // click did not come from a button! Handle other cases
        }
    }
