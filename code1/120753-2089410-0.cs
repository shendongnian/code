    Thread testThread = new Thread( () => {
        SetStatusDelegate d = new SetStatusDelegate(SetTestStatus);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("yoururl");
        request.Timeout = new TimeSpan( 0, 1, 30 );
        try
        {
            request.GetResponse();
        }
        catch( TimeoutException )
        {
             this.Invoke(d, new object[] { TestStatus.Failure});
        }
        this.Invoke(d, new object[] { TestStatus.Success});
    });
