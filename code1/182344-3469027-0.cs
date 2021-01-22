    public void qc_GetOfficerNamesCompleted(object sender, GetOfficerNamesCompletedEventArgs e)
    {
        foreach (var result in e.Results)
        {
            Items.Add(result);
        }
    }
