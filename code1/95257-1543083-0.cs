    private static void Upload()
        {
            try
            {
                Cursor=Cursors.Wait;
                Uri uri = new Uri("http://localhost/Default2.aspx");
                String filename = @"C:\Test\1.dat";
    
                client.Headers.Add("UserAgent", "TestAgent");
                client.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressCallback);
                client.UploadFileCompleted += new UploadFileCompletedEventHandler(UploadFileCompleteCallback);
                client.UploadFileAsync(uri, "POST", filename);    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace.ToString());
                Cursor=Cursors.Default;
            }
        }
  
    public void UploadFileCompleteCallback(object sender, UploadFileCompletedEventArgs e)
    {
          if(this.InvokeRequired)
          {
               // so this is called in the main GUI thread
               this.BeginInvoke(new UploadFileCompletedEventHandler(UploadFileCompleteCallback);
          }
          else
          {
              MessageBox.Show(this,"Upload done");
              Cursor=Cursors.Default;
          }
    }
