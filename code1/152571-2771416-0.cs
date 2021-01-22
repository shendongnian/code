    private void txtTelnumber_TextChanged(object sender, TextChangedEventArgs e)
    {
        lstOverview.BegingUpdate();
        lstOverview.Items.Clear();
        string data = "";
        foreach (ucTelListItem telList in _allUsers)
        {
            data = telList.User.H323 + telList.user.E164;
            if (data.Contains(txtTelnumber.Text))
                lstOverview.Items.Add(telList);
        }
        lstOverview.EndUpdate();
    }
