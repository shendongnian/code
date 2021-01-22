    public void NoGatewayStatus (string sipUsername, string phoneNumber) {
        string strURL = string.Format( "http://xxxxxxxxxxxxxxx={0}&CalledNumber={1}", sipUsername, phoneNumber );
        WebClient wc = new WebClient();
        Thread thr = new Thread( DownloadSomeStuff );
        thr.Start( strURL );
    }
    public void DownloadSomeStuff (object p_url) {
        string url = (string) p_url;
        try {
            WebClient wc = new WebClient();
            wc.DownloadString( url );
            OnGateWayCompetedAndAllThoseOtherCallbacks( this, e );
        } catch ( WebException ex ) {
            Console.WriteLine( "IsNoGateway: " + ex.Message );
        } catch ( Exception ex ) {
            Console.WriteLine( "IsNoGateway: " + ex.Message );
        }
    }
