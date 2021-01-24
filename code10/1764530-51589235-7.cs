    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Devices.Bluetooth.Rfcomm;
    using Windows.Networking.Sockets;
    using Windows.Storage.Streams;
    namespace BT
    {
    	public sealed class BluetoothConnectionHandler
    	{
    		RfcommServiceProvider provider;
    		bool isAdvertising = false;
    		StreamSocket socket;
    		StreamSocketListener socketListener;
    		DataWriter writer;
    		DataReader reader;
    		Task listeningTask;
    
    		public bool Listening { get; private set; }
            // I use Actions for transmitting the output and debug output. These are custom classes I created to pack them more conveniently and to be able to just "Trigger" them without checking anything. Replace this with regular Actions and use their invoke methods.
    		public ActionSingle<string> MessageOutput { get; private set; } = new ActionSingle<string> ();
    		public ActionSingle<string> LogOutput { get; private set; } = new ActionSingle<string> ();
    
            // These were in the samples.
    		const uint SERVICE_VERSION_ATTRIBUTE_ID = 0x0300;
    		const byte SERVICE_VERSION_ATTRIBUTE_TYPE = 0x0a; // UINT32
    		const uint SERVICE_VERSION = 200;
    
    		const bool DO_RESPONSE = true;
    
    		public async void StartServer ()
    		{
    			// Initialize the provider for the hosted RFCOMM service.
    			provider = await RfcommServiceProvider.CreateAsync (RfcommServiceId.ObexObjectPush);
    
    			// Create a listener for this service and start listening.
    			socketListener = new StreamSocketListener ();
    			socketListener.ConnectionReceived += OnConnectionReceived;
    			await socketListener.BindServiceNameAsync (provider.ServiceId.AsString (), SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);
    
    			// Set the SDP attributes and start advertising.
    			InitializeServiceSdpAttributes (provider);
    			provider.StartAdvertising (socketListener);
    			isAdvertising = true;
    		}
    
    		public void Disconnect ()
    		{
    			Listening = false;
    			if (provider != null) { if (isAdvertising) provider.StopAdvertising (); provider = null; } // StopAdvertising relentlessly causes a crash if not advertising.
    			if (socketListener != null) { socketListener.Dispose (); socketListener = null; }
    			if (writer != null) { writer.DetachStream (); writer.Dispose (); writer = null; }
    			if (reader != null) { reader.DetachStream (); reader.Dispose (); reader = null; }
    			if (socket != null) { socket.Dispose (); socket = null; }
    			if (listeningTask != null) { listeningTask = null; }
    		}
    
    		public async void SendMessage (string message)
    		{
    			// There's no need to send a zero length message.
    			if (string.IsNullOrEmpty (message)) return;
    
    			// Make sure that the connection is still up and there is a message to send.
    			if (socket == null || writer == null) { LogOutput.Trigger ("Cannot send message: No clients connected."); return; } // "No clients connected, please wait for a client to connect before attempting to send a message."
    
    			uint messageLength = (uint) message.Length;
    			byte[] countBuffer = BitConverter.GetBytes (messageLength);
    			byte[] buffer = Encoding.UTF8.GetBytes (message);
    
    			LogOutput.Trigger ("Sending: " + message);
    
    			writer.WriteBytes (countBuffer);
    			writer.WriteBytes (buffer);
    
    			await writer.StoreAsync ();
    		}
    
    
    
    		private void InitializeServiceSdpAttributes (RfcommServiceProvider provider)
    		{
    			DataWriter w = new DataWriter ();
    
    			// First write the attribute type.
    			w.WriteByte (SERVICE_VERSION_ATTRIBUTE_TYPE);
    
    			// Then write the data.
    			w.WriteUInt32 (SERVICE_VERSION);
    
    			IBuffer data = w.DetachBuffer ();
    			provider.SdpRawAttributes.Add (SERVICE_VERSION_ATTRIBUTE_ID, data);
    		}
    
    		private void OnConnectionReceived (StreamSocketListener listener, StreamSocketListenerConnectionReceivedEventArgs args)
    		{
    			provider.StopAdvertising ();
    			isAdvertising = false;
    			provider = null;
    			listener.Dispose ();
    			socket = args.Socket;
    			writer = new DataWriter (socket.OutputStream);
    			reader = new DataReader (socket.InputStream);
    			writer.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
    			reader.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
    			//StartListening ();
    			LogOutput.Trigger ("Connection established.");
    			listeningTask = new Task (() => StartListening ());
    			listeningTask.Start ();
    			// Notify connection received.
    		}
    
    		private async void StartListening ()
    		{
    			LogOutput.Trigger ("Starting to listen for input.");
    			Listening = true;
    			while (Listening)
    			{
    				try
    				{
    					// Based on the protocol we've defined, the first uint is the size of the message. [UInt (4)] + [Message (1*n)] - The UInt describes the length of the message.
    					uint readLength = await reader.LoadAsync (sizeof (uint));
    					
    					// Check if the size of the data is expected (otherwise the remote has already terminated the connection).
    					if (!Listening) break;
    					if (readLength < sizeof (uint))
    					{
    						Listening = false;
    						Disconnect ();
    						LogOutput.Trigger ("The connection has been terminated.");
    						break;
    					}
    
    					uint messageLength = reader.RReadUint (); // 
    					
    					LogOutput.Trigger ("messageLength: " + messageLength.ToString ());
    					
    					// Load the rest of the message since you already know the length of the data expected.
    					readLength = await reader.LoadAsync (messageLength);
    					
    					// Check if the size of the data is expected (otherwise the remote has already terminated the connection).
    					if (!Listening) break;
    					if (readLength < messageLength)
    					{
    						Listening = false;
    						Disconnect ();
    						LogOutput.Trigger ("The connection has been terminated.");
    						break;
    					}
    					
    					string message = reader.ReadString (messageLength);
    					MessageOutput.Trigger ("Received message: " + message);
    					if (DO_RESPONSE) SendMessage ("abcdefghij");
    				}
    				catch (Exception e)
    				{
    					// If this is an unknown status it means that the error is fatal and retry will likely fail.
    					if (SocketError.GetStatus (e.HResult) == SocketErrorStatus.Unknown)
    					{
    						Listening = false;
    						Disconnect ();
    						LogOutput.Trigger ("Fatal unknown error occurred.");
    						break;
    					}
    				}
    			}
    			LogOutput.Trigger ("Stopped to listen for input.");
    		}
    	}
    }
