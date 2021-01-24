	private async void Listen (Stream inStream)
	{
		bool Listening = true;
		CreateMessage ("Listening has been started.");
		byte[] uintBuffer = new byte[sizeof (uint)]; // This reads the first 4 bytes which form an uint that indicates the length of the string message.
		byte[] textBuffer; // This will contain the string message.
		// Keep listening to the InputStream while connected.
		while (Listening)
		{
			try
			{
                // This one blocks until it gets 4 bytes.
				await inStream.ReadAsync (uintBuffer, 0, uintBuffer.Length);
				uint readLength = BitConverter.ToUInt32 (uintBuffer, 0);
					
				textBuffer = new byte[readLength];
                // Here we know for how many bytes we are looking for.
				await inStream.ReadAsync (textBuffer, 0, (int) readLength);
				string s = Encoding.UTF8.GetString (textBuffer);
				CreateMessage ("Received: " + s);
			}
			catch (Java.IO.IOException e)
			{
				CreateMessage ("Error: " + e.Message);
				Listening = false;
				break;
			}
		}
		CreateMessage ("Listening has ended.");
	}
