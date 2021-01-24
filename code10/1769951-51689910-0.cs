	this.SerialDevice = new SerialPort(this.Port);
	this.SerialDevice.BaudRate = 115200;
	this.SerialDevice.DataReceived += OnDataReceived;
	this.SerialDevice.Open();
    ...
	private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		var serialDevice = sender as SerialPort;
		var buffer = new byte[serialDevice.BytesToRead];
		serialDevice.Read(bytes, 0, buffer.Length);
		// process data on the GUI thread
		Application.Current.Dispatcher.Invoke(new Action(() => {
			... do something here ...
		}));
	}
