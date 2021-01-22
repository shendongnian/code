    private void  service_GetAccountsCompleted(object sender, GetAccountsCompletedEventArgs e)
    {
      foreach (var item in e.Result)
      {   
          MyMusic.Add(new Recording(item.acctnumber, item.acpk, new DateTime(2011, 4, 18)));
          grdData.DataContext = MyMusic;               
      }
     
