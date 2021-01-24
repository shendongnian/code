	this.Scanner = new SerialPort(this.SymbolPort);
	this.Scanner.BaudRate = 9600;
	this.Scanner.DataReceived += Scanner_DataReceived;
	this.Scanner.Open();
	.
	.
	.
	private void Scanner_DataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		var len = this.Scanner.BytesToRead;
		var bytes = new byte[len];
		this.Scanner.Read(bytes, 0, len);
		var str = Encoding.ASCII.GetString(bytes);
		// do something with str here
	}
