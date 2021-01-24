	private async void SendMessage (string message)
	{
		uint messageLength = (uint) message.Length;
		byte[] countBuffer = BitConverter.GetBytes (messageLength);
		byte[] buffer = Encoding.UTF8.GetBytes (message);
			
		await outStream.WriteAsync (countBuffer, 0, countBuffer.Length);
		await outStream.WriteAsync (buffer, 0, buffer.Length);
	}
