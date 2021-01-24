    static void Main(string[] args)
        {
            //Create a new instance of class TcAdsClient
            TcAdsClient tcClient = new TcAdsClient();
            
            try
            {
                // Connect to TwinCAT System Service port 10000
                tcClient.Connect(AmsPort.SystemService);
                // Send desired state
                tcClient.WriteControl(new StateInfo(AdsState.Config, tcClient.ReadState().DeviceState));
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            finally
            {
                tcClient.Dispose();
            }
        }
