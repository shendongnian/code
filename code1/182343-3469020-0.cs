    public void qc_GetOfficerNamesCompleted(object sender, GetOfficerNamesCompletedEventArgs e)
    {
        // Now how do I add e.Results to above collection?
        foreach(var item in e.Results)
        {
            this.Items.Add(item);
        }
    }
