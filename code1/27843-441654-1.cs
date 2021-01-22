	public void DoorOpener()
	{
		while (true)
		{
			SerialPort serialPort = new SerialPort();
			Thread.Sleep(1000);
			serialPort.PortName = "COM1";
			serialPort.BaudRate = 9600;
			serialPort.DataBits = 8;
			serialPort.StopBits = StopBits.One;
			serialPort.Parity = Parity.None;
			try
			{
				serialPort.Open();
			}
			catch
			{
			}
			if (serialPort.IsOpen)
			{
				serialPort.DtrEnable = true;
				Thread.Sleep(1000);
				serialPort.Close();
			}
			serialPort.Dispose();
		}
	}
