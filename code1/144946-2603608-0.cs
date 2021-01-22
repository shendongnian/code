    public class MyService : IMyService
    {
        public void Login()
        {
            var callback = 
                OperationContext.Current.GetCallbackChannel<ILoginCallback>();
            ThreadPool.QueueUserWorkItem(s =>
            {
                var status = VendorLibrary.PerformLogin();
                callback.ReportLoginStatus(status);
            });
        }
    }
