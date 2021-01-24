    private async void Start_Click(object sender, RoutedEventArgs e)
    {
        ProcessProgress.IsIndeterminate = true;
        ProcessProgress.Visibility = Visibility.Visible;
          ...
        await Task.Run(()=>
        {
            //process starts here
            var fP = new FileProcessor();
       
            ...
        });
        //We are back in the UI thread, we can modify the UI
        ProcessProgress.IsIndeterminate = false;
        ProcessProgress.Value = ProcessProgress.Maximum;
    }
