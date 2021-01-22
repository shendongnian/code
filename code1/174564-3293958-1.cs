    private void UserMoodChange(object sender, UserSomethingChangedArgs args)
    {
      var listViewItem = new ListViewItem(new[]
        {
          args.Time.ToString(),
          args.Contact.UserInfo.Name,
          args.Contact.Status.ToLocalString(),
          args.Contact.Mood
        }, args.Contact.Status.GetImageIndex());
      
      listView1.Items.Add(listViewItem);
      listViewItem.EnsureVisible();
      NotifyStatus(args);
      RefreshContactList();
      LogIt(args);
    }
