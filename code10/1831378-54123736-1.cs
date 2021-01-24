    protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.gatt_services_characteristics);
			mServiceManager = new ServiceManager (this);
            Intent gattServiceIntent = new Intent(this, typeof (YourService));
			BindService (gattServiceIntent, mServiceManager, Bind.AutoCreate);
       }
    protected override void OnResume ()
		{
			base.OnResume ();
			//RegisterReceiver
		}
	protected override void OnPause ()
		{
			base.OnPause ();
			//UnregisterReceiver;
		}
	protected override void OnDestroy ()
		{
			base.OnDestroy ();
			//UnbindService;
		
		}
    class ServiceManager : BroadcastReceiver
	{   
		Activity _activity;
		public ServiceManager (Activity dca)
		{
			_activity= dca;
		}
		public override void OnReceive (Context context, Intent intent)
		{
			String action = intent.Action;
			if (BluetoothLeService.ACTION_GATT_CONNECTED == action) {
				//do Something
			} else if (BluetoothLeService.ACTION_GATT_DISCONNECTED == action) {
				//do Something
			}
		}
	}
