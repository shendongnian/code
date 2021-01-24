    private void ConvertBtn_OnClick(object sender, RoutedEventArgs e)
    {    
      ProgressIndicator.BusyContent = string.Format("Inprogress, please wait..."); 
      Task.Factory.StartNew(() =>
      {
        ConversionToExcel();//My conversion method
     
      }).ContinueWith((task) => { ProgressIndicator.IsBusy = false; }, TaskScheduler.FromCurrentSynchronizationContext()
      );
    }
