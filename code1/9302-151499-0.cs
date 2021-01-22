    protected void lsvnotificationList_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
      string Email = e.NewValues["EmailAddress"].ToString();
      int id = Convert.ToInt32(e.NewValues["ID"]);
    
      using (ESLinq.ESLinqDataContext db = new ESLinq.ESLinqDataContext(connectionString))
      {
        List<NotificationList> compare = db.NotificationLists.Where(n => n.ID = id).ToList();
    
        if (!compare.Any())
        {
          lblmessage.Text = "Record Does Not Exist";
        }
        else
        {
          NotificationList Notice = compare.First();
          Notice.EmailAddress = Email;
          db.SubmitChanges();
        }
      }
      lsvnotificationList.EditIndex = -1;
      BindlistviewNotification();
    
    }
