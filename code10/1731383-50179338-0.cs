    TcpClient tcp = new TcpClient();
    #region Try connect
    IAsyncResult ar = tcp.BeginConnect(host, port, (ari) => {
        TcpClient tcpi = (TcpClient)ari.AsyncState;
        try {
            tcpi.EndConnect(ari);
        } catch { }
        if (tcpi.Connected) {
            return; //return IAsyncResult and waitone will be true
        }
        //otherwise it will close the tcpi and never return, causing the timeout to kickin.
        tcpi.Close();
    }, tcp);
    #endregion
    #region If timed out, or not connected return null
    if (!ar.AsyncWaitHandle.WaitOne(_connectTimeout, false) || !tcp.Connected) {
        return null; //this is my use case, you might want to do something different
    }
    #endregion
    return tcp;
