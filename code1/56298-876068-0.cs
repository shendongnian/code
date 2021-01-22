    public class Balance : IDisposable
    {
        //Constructor
        WebClient wc;
        public Balance()
        {
            wc = new WebClient();
            //Create event handler for the progress changed and download completed events
            try {
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
            } catch {
                wc.Dispose();
                throw;
            }
        }
        ~Balance()
        {
            this.Dispose(false);
        }
        
        //Get the current balance for the user that is logged in.
        //If the balance returned from the server is NULL display error to the user.
        //Null could occur if the DB has been stopped or the server is down.       
        public void GetBalance(string sipUsername)
        {
            //Remove the underscore ( _ ) from the username, as this is not needed to get the balance.
            sipUsername = sipUsername.Remove(0, 1);
            string strURL =
                string.Format("https://www.xxxxxxx.com", 
                sipUsername);
            //Download only when the webclient is not busy.
            if (!wc.IsBusy)
            { 
                // Download the current balance.
                wc.DownloadStringAsync(new Uri(strURL));             
            }
            else
            {
                Console.Write("Busy please try again");
            }
        }
        //return and display the balance after the download has fully completed
        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //Pass the result to the event handler
        }
        private bool isDisposed = false;
        //Dispose of the balance object
        public void Dispose()
        {
            if (!isDisposed)
                Dispose(true);
            GC.SuppressFinalize(this);
        }
        //Remove the event handlers
        private void Dispose(bool disposing)
        {
            isDisposed = true;
            if (disposing)
            {
				wc.DownloadProgressChanged -= new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                wc.DownloadStringCompleted -= new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                wc.Dispose();
            }               
        }
    }
