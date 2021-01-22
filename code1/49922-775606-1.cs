    protected void _postsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeletePost") // Replace DeletePost with the name of your command
        {
            // Get the passed parameter from e.CommandArgument
            // e.g. if passed an int use:
            // int id = Convert.ToInt32(e.CommandArgument);
        }
    }
