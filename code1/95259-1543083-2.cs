    public partial class Form1 : Form
    {
        private static WebClient client = new WebClient();
        private static ManualResetEvent uploadLock = new ManualResetEvent(false);
        
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
          // this callback will be invoked by the async upload handler on a ThreadPool thread, so we cannot touch anything GUI-related. For this we have to switch to the GUI thread using control.BeginInvoke
          if(this.InvokeRequired)
          {
               // so this is called in the main GUI thread
               this.BeginInvoke(new UploadFileCompletedEventHandler(UploadFileCompleteCallback); // beginInvoke frees up the threadpool thread faster. Invoke would wait for completion of the callback before returning.
          }
          else
          {
              Cursor=Cursors.Default;
              this.enabled=true;
              MessageBox.Show(this,"Upload done","Done");
          }
    public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Upload();
            }
        }
    }
