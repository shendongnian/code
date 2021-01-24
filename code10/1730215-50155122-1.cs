    public class DataServiceConnection : Object, IServiceConnection
        {
            public DataService Service { get; private set; }
            public MyDataActivity DataActivity;
            public event EventHandler<bool> ServiceConnectionChanged;
            public DataServiceConnection(MyDataActivity myDataActivity)
            {
                DataActivity = myDataActivity;
            }
    
            public void OnServiceConnected(ComponentName name, IBinder service)
            {
                dataServiceBinder = service as DataServiceBinder;
                Service = dataServiceBinder.Service;
                ServiceConnectionChanged?.Invoke(this, true);
            }
    
            public void OnServiceDisconnected(ComponentName name)
            {
                ServiceConnectionChanged?.Invoke(this, false);
                Service = null;
            }
        }
