	using System;
	using System.IO;
	using System.Net;
	using System.Net.Sockets;
	public class EchoServer
	{
		public static void Main()
		{
			TcpListener listener = null;
			byte[] datalength = new byte[4];
			try
			{
				listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1234);
				listener.Start();
				Console.WriteLine("TCP Server Has Started....");
				while (true)
				{
					TcpClient client = listener.AcceptTcpClient();
					StreamReader reader = new StreamReader(client.GetStream());
					StreamWriter writer = new StreamWriter(client.GetStream());
					string s = string.Empty;
					string b = string.Empty;
					s = reader.ReadLine();
					{
						string FilePath = "Sample.txt";
						File.AppendAllText(FilePath, DateTime.Now.ToString());
						File.AppendAllText(FilePath, "From client -> Heart Rates : " + s);
					}
					reader.Close();
					writer.Close();
					client.Close();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine(e);
				//Console.WriteLine(e.ToString());
			}
			finally
			{
				Console.WriteLine("Listener stopped");
				if (listener != null)
				{
					listener.Stop();
				}
			}
		}
	}
