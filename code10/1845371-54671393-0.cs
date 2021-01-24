    private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (e.UserState != null)
        {
            pop.SetLable(e.UserState.ToString());
            listBox2.Items.Add(e.UserState.ToString());
        }
    }
