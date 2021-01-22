    private void txtTelnumber_TextChanged(object sender, TextChangedEventArgs e)
    { 
        lstOverview.DataSource=_allUsers.FindAll(delegate(ObjType telList)
        {
            return (telList.User.H323.Contains(txtTelnumber.Text) || telList.user.E164.Contains(txtTelnumber.Text) );
        });
    }
