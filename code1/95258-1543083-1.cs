    private void Upload()
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
                this.Cursor=Cursors.Default;
                this.Enabled=false;
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
              Cursor=Cursors.Default;
              this.enabled=true;
              MessageBox.Show(this,"Upload done","Done");
          }
    }
