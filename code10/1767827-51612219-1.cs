		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;
		namespace MyTcpListener
		{
			interface ITcpListener : IDisposable
			{
				event ConnectionCreatedHandler OnConnectionCreated;
				event DataReceivingHandler OnDataReceiving;
				event DataReceivedHandler OnDataReceived;
				event ResponseSendingHandler OnResponseSending;
				event ResponseSentHandler OnResponseSent;
				event ErrorHandler OnError;
				object Tag { get; set; }
				void StartListening(string host, int port);
				void Dispose();
			}
		}
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Threading;
		using System.Net;
		using System.Net.Sockets;
		namespace MyTcpListener
		{
			public delegate void ConnectionCreatedHandler(object sender, TcpConnectionEventArgs e);
			public delegate void DataReceivingHandler(object sender, TcpConnectionEventArgs e);
			public delegate void DataReceivedHandler(object sender, TcpConnectionEventArgs e);
			public delegate void ResponseSendingHandler(object sender, TcpConnectionEventArgs e);
			public delegate void ResponseSentHandler(object sender, TcpConnectionEventArgs e);
			public delegate void DataSendingHandler(object sender, TcpConnectionEventArgs e);
			public delegate void DataSentHandler(object sender, TcpConnectionEventArgs e);
			public delegate void ErrorHandler(object sender, string message);
			class TcpListener : ITcpListener
			{
				public event ConnectionCreatedHandler OnConnectionCreated;
				public event DataReceivingHandler OnDataReceiving;
				public event DataReceivedHandler OnDataReceived;
				public event ResponseSendingHandler OnResponseSending;
				public event ResponseSentHandler OnResponseSent;
				public event ErrorHandler OnError;
				public ManualResetEvent processCompleted = new ManualResetEvent(false);
				public HubTcpListener()
				{
				}
				public object Tag { get; set; }
				
				public void StartListening(string host, int port) 
				{
					int bufferSize = 1024 * 1024 * 1;
					byte[] buffer = new byte[bufferSize];
					bool keppAlive = true;
					TcpConnectionEventArgs tcpServerConnectionEventArgs = new TcpConnectionEventArgs();
					IPAddress[] ipAddreses = Dns.GetHostAddresses(host);
					IPEndPoint ipEndpoint = new IPEndPoint(ipAddreses[0], port);
					Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					try
					{
						listenerSocket.Bind(ipEndpoint);
						listenerSocket.Listen(500);
						tcpServerConnectionEventArgs.HandlerSocket = listenerSocket;
						tcpServerConnectionEventArgs.ReceivedTime = DateTime.Now;
						if (OnConnectionCreated != null) 
						{
							OnConnectionCreated(this, tcpServerConnectionEventArgs);
						}
						while (keppAlive) 
						{
							try
							{
								processCompleted.Reset();
								listenerSocket.BeginAccept(new AsyncCallback(HandleAcceptCallBack), listenerSocket);
								processCompleted.WaitOne();
							}
							catch (Exception ex)
							{
								if (OnError != null) 
								{
									OnError(this, ex.Message);
								}
							}
						}
					}
					catch (Exception)
					{
					throw;
					}
				}
				private void HandleAcceptCallBack(IAsyncResult asyndResult) 
				{
					processCompleted.Set();
					Socket listener = (Socket)asyndResult.AsyncState;
					Socket handler = listener.EndAccept(asyndResult);
					StateObject stateObject = new StateObject() { clientSocket = handler };
					TcpConnectionEventArgs tcpServerConnectionEventArgs = new TcpConnectionEventArgs();
					tcpServerConnectionEventArgs.ReceivedTime = DateTime.Now;
					tcpServerConnectionEventArgs.HandlerSocket = handler;
					tcpServerConnectionEventArgs.ReceivedData = "";
					if (OnDataReceiving != null)
					{
						OnDataReceiving(this, tcpServerConnectionEventArgs);
					}
					handler.BeginReceive(stateObject.buffer, 0, StateObject.bufferSize, 0, new AsyncCallback(HandleReadCallBack), stateObject);
				}
				private void HandleReadCallBack(IAsyncResult asyncResult) 
				{
					string contents = string.Empty;
					StateObject state = (StateObject)asyncResult.AsyncState;
					Socket handler = state.clientSocket;
					int bytesLength = handler.EndReceive(asyncResult);
					TcpConnectionEventArgs tcpServerConnectionEventArgs = new TcpConnectionEventArgs();
					tcpServerConnectionEventArgs.ReceivedTime = DateTime.Now;
					tcpServerConnectionEventArgs.HandlerSocket = handler;
					if (bytesLength > 0)
					{
						state.stringBuilder.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesLength));
						contents = state.stringBuilder.ToString();
						tcpServerConnectionEventArgs.ReceivedData = contents; ;
						if (OnDataReceived != null)
						{
							OnDataReceived(this, tcpServerConnectionEventArgs);
						}
						Send(handler, contents);
					}
					else 
					{
						handler.BeginReceive(state.buffer, 0, StateObject.bufferSize, 0, new AsyncCallback(HandleReadCallBack), state);
					}
				}
				private void Send(Socket handler, string data) 
				{
					TcpConnectionEventArgs tcpServerConnectionEventArgs = new TcpConnectionEventArgs();
					tcpServerConnectionEventArgs.ReceivedTime = DateTime.Now;
					tcpServerConnectionEventArgs.HandlerSocket = handler;
					tcpServerConnectionEventArgs.ReceivedData = data;
					if (OnResponseSending != null)
					{
						OnResponseSending(this, tcpServerConnectionEventArgs);
						data = tcpServerConnectionEventArgs.ReceivedData;
					}
					byte[] bytes = Encoding.ASCII.GetBytes(data);
					handler.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(HandleSendCallBack), handler);
				}
				private void HandleSendCallBack(IAsyncResult asyncResult) 
				{
					try
					{
						Socket handler = (Socket)asyncResult.AsyncState;
						int bytesSendLength = handler.EndSend(asyncResult);
						TcpConnectionEventArgs tcpServerConnectionEventArgs = new TcpConnectionEventArgs();
						tcpServerConnectionEventArgs.ReceivedTime = DateTime.Now;
						tcpServerConnectionEventArgs.HandlerSocket = handler;
						if (OnResponseSent != null)
						{
							OnResponseSent(this, tcpServerConnectionEventArgs);
						}
						handler.Shutdown(SocketShutdown.Both);
						handler.Close();
					}
					catch (Exception)
					{
						throw;
					}
				}
				public void Dispose()
				{
					Dispose(true);
					GC.SuppressFinalize(this);
				}
				protected virtual void Dispose(bool disposing)
				{
					if (disposing)
					{
						if (this.processCompleted != null)
						{
							this.processCompleted.Dispose();
						}
					}
				}
			}
		}
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Net;
		using System.Net.Sockets;
		namespace MyTcpListener
		{
			public class TcpConnectionEventArgs : EventArgs
			{
				public Socket HandlerSocket { get; set; }
				public DateTime ReceivedTime { get; set; }
				public string ReceivedData { get; set; }
				public long TransactionID { get; set; }
				public long ConnectorID { get; set; }
			}
		}
		namespace MyTcpListener
		{
			public class StateObject
			{
				public Socket clientSocket = null;
				public const int bufferSize = (1024 * 1024) * 1; // 1 MB
				public byte[] buffer = new byte[bufferSize];
				public StringBuilder stringBuilder = new StringBuilder();
			}
		}
