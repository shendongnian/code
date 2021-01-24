    void OnTagsReported(ImpinjReader sender, TagReport report)
    {
      Debug.Log("OnTagsReported");
      // This event handler is called asynchronously 
      // when tag reports are available.
      // Loop through each tag in the report 
      // and print the data.
      foreach (Tag tag in report)
      {
        Debug.Log(tag.Epc);
        List<AppUser> appUsers = MySqlTestScript.sharedInstance().users;
        int numUsers = appUsers.Count;
        Debug.Log(numUsers);
        for (int i = 0; i < numUsers; i++)
        {
          if (tag.Epc.ToString().Trim() == appUsers[i].rfid)
          {
            // TODO References the Name 
            Loom.QueueOnMainThread(() => {
              if (i < namesTxt.Count) namesTxt[i].Text = appUsers[i].username; //assumes textnames is a "List" of textboxes and is already populated with instances of text1, text2 text3 etc. The if is just to guard against there being more rows in the DB than textboxes
            });
          }
        }
      }
    }
  
