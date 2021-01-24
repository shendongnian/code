    Thread doThis = new Thread(delegate ()
    {
        using (var db = new ApplicationDbContext())
        {
          DataCollection dataCollection = new DataCollection();
          dataCollection.InsertData(DateTime.Now);
        }
    });
