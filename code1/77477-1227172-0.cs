    private const int OPERATION_TIMEOUT = 5000;
    private MyServiceClient m_client = new MyServiceClient();
    public bool IsAlive() {
        try {
            logger.Debug("PassThruService IsAlive.");
            bool isAlive = false;
            ManualResetEvent isAliveMRE = new ManualResetEvent(false);
            m_client.IsAliveComplete += (s, a) => { isAlive = a.Result; isAliveMRE.Set(); };
            m_client.IsAliveAsync();
            if (isAliveMRE.WaitOne(OPERATION_TIMEOUT)) {
                return isAlive;
            }
            else {
                throw new TimeoutException();
            }
        }
        catch (Exception excp) {
            logger.Error("Exception PassThruService IsAlive. " + excp.Message);
            throw;
        }
 
