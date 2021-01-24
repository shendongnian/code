    private void ConvertBtn_OnClick(object sender, RoutedEventArgs e)
    {    
      ProgressIndicator.BusyContent = string.Format("Inprogress, please wait..."); 
      Task.Factory.StartNew(() =>
      {
        ConversionToExcel();//My conversion methode
        for (int i = 0; i < 10; i++)
     
      }).ContinueWith((task) => { ProgressIndicator.IsBusy = false; }, TaskScheduler.FromCurrentSynchronizationContext()
      );
    }
