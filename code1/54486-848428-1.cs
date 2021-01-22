    public void NoGatewayStatus (string sipUsername, string phoneNumber) {
        string strURL = string.Format( "http://xxxxxxxxxxxxxxx={0}&CalledNumber={1}", sipUsername, phoneNumber );
        ManualResetEvent wait1 = new ManualResetEvent( false );
        WebClient wc = new WebClient();
        Thread thr = new Thread( DownloadSomeStuff );
        thr.Start( new DlArguments( strURL, wait1 ) );
        // do the other three
        if ( !wait1.WaitOne( 10000 ) ) {
            Console.WriteLine( "DownloadSomeStuff timed out" );
            return;
        }
        if ( !wait2.WaitOne( 10000 ) ) {
            Console.WriteLine( "DownloadOtherStuff timed out" );
            return;
        }
        if ( !wait3.WaitOne( 10000 ) ) {
            Console.WriteLine( "DownloadMoreStuff timed out" );
            return;
        }
    }
    public void DownloadSomeStuff (object p_args) {
        DlArguments args = (DlArguments) p_args;
        try {
            WebClient wc = new WebClient();
            wc.DownloadString( args.Url );
            args.WaitHandle.Set();
        } catch ( Exception ) {
            // boring stuff
        }
    }
    private class DlArguments
    {
        public DlArguments (string url, ManualResetEvent wait_handle) {
            this.Url = url;
            this.WaitHandle = wait_handle;
        }
        public string Url { get; set; }
        public ManualResetEvent WaitHandle { get; set; }
    }
