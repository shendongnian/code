    public class MyDataActivity : AppCompatActivity
        {
            private DataServiceConnection DataServiceConnection;
    
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                if (DataServiceConnection == null)
                {
                    this.DataServiceConnection = new DataServiceConnection();
                }
    
                Intent serviceToStart = new Intent(this, typeof(DataService));
                BindService(serviceToStart, this.DataServiceConnection, Bind.AutoCreate);
                DataServiceConnection.ServiceConnectionChanged += ServiceConnectionChanged;
                SetContentView(Resource.Layout.MyDataLayout);
    
            }
            private void ServiceConnectionChanged(object sender, bool isConnected)
            {
                if(DataServiceConnection.Service == null)
                {
                    return;
                }
                if(isConnected)
                {
                    var adapter = new MyDataAdapter(DataServiceConnection.Service.MyObjectList);
                }
            }
            protected override void OnResume()
            {
                var intent = new Intent(this, typeof(DataService));
                BindService(intent, DataServiceConnection, Bind.AutoCreate);
                base.OnResume();
            }
    
            protected override void OnPause()
            {
                UnbindService(DataServiceConnection);
                base.OnPause();
            }
