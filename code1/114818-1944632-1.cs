    protected void CouncilListView_ItemInserted(Object sender, ListViewInsertedEventArgs e)
    {
        foreach (DictionaryEntry Emailentry in e.Values)
        {
            if (Emailentry.Key == "Email") //table field name is "email"
            {
                message.To.Add(new MailAddress(Emailentry.Value.ToString()));
            }
        }
    }
