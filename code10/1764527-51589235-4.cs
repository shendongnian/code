    using Java.Util;
    using System.Text;
    using System.IO;
    using Android.Runtime;
    using System.Threading.Tasks;
    TestClass
    {
        // The UUIDs will be displayed down below if not known.
        const string TARGET_UUID = "00001105-0000-1000-8000-00805f9b34fb";
		BluetoothSocket socket = null;
		OutputStreamInvoker outStream = null;
		InputStreamInvoker inStream = null;
        void Connect ()
        {
		    BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
		    if (adapter == null) CreateMessage ("No Bluetooth adapter found.");
		    else if (!adapter.IsEnabled) CreateMessage ("Bluetooth adapter is not enabled.");
					
		    List<BluetoothDevice> L = new List<BluetoothDevice> ();
		    foreach (BluetoothDevice d in adapter.BondedDevices)
		    {
			    CreateMessage ("D: " + d.Name + " " + d.Address + " " + d.BondState.ToString ());
			    L.Add (d);
		    }
		    BluetoothDevice device = null;
		    device = L.Find (j => j.Name == "PC-NAME");
		    if (device == null) CreateMessage ("Named device not found.");
		    else
		    {
			    CreateMessage ("Device has been found: " + device.Name + " " + device.Address + " " + device.BondState.ToString ());
		    }
					
		    socket = device.CreateRfcommSocketToServiceRecord (UUID.FromString (TARGET_UUID));
		    await socket.ConnectAsync ();
		    if (socket != null && socket.IsConnected) CreateMessage ("Connection successful!");
		    else CreateMessage ("Connection failed!");
		    inStream = (InputStreamInvoker) socket.InputStream;
		    outStream = (OutputStreamInvoker) socket.OutputStream;
		    if (socket != null && socket.IsConnected)
		    {
		    	Task t = new Task (() => Listen (inStream));
		    	t.Start ();
		    }
		    else throw new Exception ("Socket not existing or not connected.");
        }
    }
