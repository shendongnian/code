    void DownloadButton_Click(object sender, RoutedEventArgs e)
    {
      var dialog = new SaveFileDialog();
      if (dialog.ShowDialog().Value)
      {
        var web = new WebClient();
        web.OpenReadCompleted = (s, args) =>
        {
          try
          {
            using (args.Result)
            using (Stream streamOut = args.UserState As Stream)
            {
              Pump(args.Result, streamOut);
            }
          }
          catch
          {
             // Do something sensible when the download has failed.
          }
 
        };
        web.OpenReadAsync(UriOfWmv,  ShowDialog.OpenFile()); 
      }
    }
    private static void Pump(Stream input, Stream output)
    {
      byte[] bytes = new byte[4096];
      int n;
      while((n = input.Read(bytes, 0, bytes.Length)) != 0)
      {
        output.Write(bytes, 0, n);
      }
    }
