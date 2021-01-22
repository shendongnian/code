        protected void rpMemList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string a = e.CommandArgument.ToString();
            string b = e.CommandName.ToString();
            string c = e.CommandSource.ToString();
            string d = e.Item.ToString();
        }
