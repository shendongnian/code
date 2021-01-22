	public class MySerialReader : IDisposable
	{
		private SerialPort serialPort;
		private Queue<byte> recievedData = new Queue<byte>();
		public MySerialReader()
		{
			serialPort = new SerialPort();
			serialPort.Open();
			serialPort.DataReceived += serialPort_DataReceived;
		}
		void serialPort_DataReceived(object s, SerialDataReceivedEventArgs e)
		{
			byte[] data = new byte[serialPort.BytesToRead];
			serialPort.Read(data, 0, data.Length);
			data.ToList().ForEach(b => recievedData.Enqueue(b));
			processData();
		}
		void processData()
		{
			// Determine if we have a "packet" in the queue
			if (recievedData.Count > 50)
			{
				var packet = Enumerable.Range(0, 50).Select(i => recievedData.Dequeue());
			}
		}
		public void Dispose()
		{
			if (serialPort != null)
				serialPort.Dispose();
		}
