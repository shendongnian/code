    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows;
    
    public partial class MainWindow : Window
    {
        private Websocket_listen _listener;
        public MainWindow()
        {
    		_listener = new Websocket_listen("127.0.0.1", 13000);
    		_listener.StringReceived += _listener_StringReceived;
    		_listener.Start();
    	}
    
    	private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    	{
    		_running = false;
    		_listener.Stop();
    	}
    
    	private void _listener_StringReceived(string received)
    	{
    	}
    }
    
    public class Websocket_listen
    {
    	public readonly int port = 13000;
    	public readonly IPAddress localAddr;
    
    	private TcpListener server = null;
    	private TcpClient client = null;
    	private NetworkStream stream = null;
    	private bool connected = false;
    	private byte[] bytes = new byte[2048];
    	private byte[] _last_key = new byte[4];
    	private int _last_message_length;
    	private bool read_more_message;
    	private Thread _current_thread;
    	private bool _running = true;
    	private int _received = 0;
    	private StringBuilder _results = new StringBuilder();
    
    	public event Action<string> StringReceived = null;
    
    	public Websocket_listen(string ipaddress, int port)
    	{
    		this.port = port;
    		localAddr = IPAddress.Parse(ipaddress);
    		server = new TcpListener(localAddr, port);
    	}
    
    	public void _running_loop()
    	{
    
    		while (_running)
    		{
    			try
    			{
    
    				server.Server.ReceiveTimeout = 5000;
    				server.Server.SendTimeout = 5000;
    				client = server.AcceptTcpClient();
    				// Get a stream object for reading and writing
    				stream = client.GetStream();
    			}
    			catch (Exception ex)
    			{
    				continue;
    			}
    
    			while (_running)
    			{
    				try
    				{
    					try
    					{
    
    						l.AcquireWriterLock(-1);
    						if (messsages.Count > 0)
    						{
    							byte[] msg = System.Text.Encoding.ASCII.GetBytes(messsages[0]);
    							//byte[] msg = System.Text.Encoding.ASCII.GetBytes("Connected to " + Environment.MachineName);
    							Array.Copy(msg, 0, bytes, 2, msg.Length);
    							bytes[0] = 0x81;
    							bytes[1] = (byte)msg.Length;
    							// Send back a response.
    							stream.Write(bytes, 0, msg.Length + 2);
    							messsages.RemoveAt(0);
    						}
    					}
    					finally
    					{
    						l.ReleaseWriterLock();
    					}
    
    				}
    				catch { }
    
    				try
    				{
    					_received = stream.Read(bytes, 0, bytes.Length);
    				}
    				catch
    				{
    					continue;
    				}
    				if (_received == 0)
    					continue;
    
    				if (!connected)
    				{
    					_is_connection();
    					continue;
    				}
    
    				if (!_parse_message())
    					break;
    			}
    		}
    
    		try
    		{
    			stream.Close();
    			client.Close();
    		}
    		catch (Exception ex)
    		{
    
    		}
    	}
    
    	private bool _parse_message()
    	{
    		int offset = 0;
    		int message_length = 0;
    		if (read_more_message)
    		{
    			_last_message_length -= bytes.Length;
    			message_length = _last_message_length;
    			if (message_length < bytes.Length)
    				message_length += 8;
    		}
    		else
    		{
    			_results.Clear();
    			var trigger = bytes[0];
    			var magic_byte = bytes[1];
    			bool is_text = (0x1 & trigger) != 0;
    			bool is_fin = (0x80 & trigger) != 0;
    
    			if (trigger == 0x88)
    			{
    				connected = false;
    				return false;
    			}
    			/*
    			text = 0x81
    			binary = 0x82
    			close 0x88
    			ping 0x89
    			pong -0x8A
    			*/
    
    
    			if (!is_fin)
    			{
    				return true;
    			}
    
    			if (!is_text)
    			{
    				return true;
    			}
    
    			//If the second byte minus 128 is between 0 and 125, this is the length of message. 
    			//If it is 126, the following 2 bytes (16-bit unsigned integer), if 127, the following 8 bytes (64-bit unsigned integer) are the length.
    			var r = magic_byte - 128;
    			var key_starts_at = 0;
    			if (r <= 125)
    			{
    				key_starts_at = 2;
    				message_length = r;
    			}
    			else if (r == 126)
    			{
    				key_starts_at = 4;
    				message_length = BitConverter.ToUInt16(new byte[] { bytes[3], bytes[2] }, 0);
    			}
    			else if (r == 127)
    			{
    				key_starts_at = 10;
    				for (var m = 7; m >= 0; --m)
    				{
    					message_length += bytes[m] << (8 * (7 - m));
    				}
    			}
    			else
    			{
    				// not documented
    			}
    			//// because its encoded
    			_last_message_length = message_length;
    			Array.Copy(bytes, key_starts_at, _last_key, 0, 4);
    
    			offset = key_starts_at + 4;
    
    		}
    		for (var mx = 0; mx < message_length && offset + mx < bytes.Length; ++mx)
    		{
    			bytes[offset + mx] = (byte)(bytes[offset + mx] ^ _last_key[mx % 4]);
    		}
    
    		var new_result = System.Text.Encoding.ASCII.GetString(bytes, offset, Math.Min(message_length, bytes.Length - offset));
    		_results.Append(new_result);
    		read_more_message = message_length > bytes.Length;
    
    		if (!read_more_message)
    		{
    			try
    			{
    				StringReceived?.Invoke(_results.ToString());
    			}
    			catch (Exception ex)
    			{
    
    			}
    		}
    
    		return true;
    	}
    
    	private void _is_connection()
    	{
    		try
    		{
    			string data = System.Text.Encoding.ASCII.GetString(bytes, 0, _received);
    
    			if (!new Regex("^GET").IsMatch(data))
    				return;
    			Byte[] response = Encoding.UTF8.GetBytes("HTTP/1.1 101 Switching Protocols" + Environment.NewLine
    				+ "Connection: Upgrade" + Environment.NewLine
    				+ "Upgrade: websocket" + Environment.NewLine
    				+ "Sec-WebSocket-Accept: " + Convert.ToBase64String(
    					SHA1.Create().ComputeHash(
    						Encoding.UTF8.GetBytes(
    							new Regex("Sec-WebSocket-Key: (.*)").Match(data).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
    						)
    					)
    				) + Environment.NewLine
    				+ Environment.NewLine);
    
    			stream.Write(response, 0, response.Length);
    			connected = true;
    
    		}
    		catch (Exception ex)
    		{
    
    		}
    	}
    
    	public void Stop()
    	{
    		_running = false;
    	}
    
    	public void Start()
    	{
    		// Start listening for client requests.
    		server.Start();
    
    
    		_current_thread = new Thread(new ThreadStart(_running_loop));
    		_current_thread.Start();
    
    	}
    	ReaderWriterLock l = new ReaderWriterLock();
    	List<string> messsages = new List<string>();
    	internal void Send(string msg)
    	{
    	 try
    		{
    			l.AcquireWriterLock(-1);
    
    			messsages.Add(msg);
    		}   
    		catch
    		{
    
    		}
    		finally
    		{
    			l.ReleaseWriterLock();
    
    		}
    	}
    }
