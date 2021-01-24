    public class bluetoothConnectionActivity : AppCompatActivity
    {
        Button buttonConnect;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_bluetoothConnection);
            buttonConnect = FindViewById<Button>(Resource.Id.connectButton);
        }
    
        protected void onActivityResult(int requestCode, int resultCode, Intent data)
        {
            if (resultCode == constants.RESULT_OK)
            {
                Log.Info(tag, MethodBase.GetCurrentMethod().Name + ": Bluetooth has been activated");
                buttonConnect.Enabled = true;
            }
        }
    }
