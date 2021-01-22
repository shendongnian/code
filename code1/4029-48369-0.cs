using System;
using System.Net.Sockets;
using System.Net;
namespace ConsoleApplication1
{
	class Program
	{
		class ClassA : IDisposable
		{
			protected Socket s;
			public ClassA()
			{
				s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				s.Bind(new IPEndPoint(IPAddress.Any, 5678));
			}
			public void Dispose()
			{
				s.Close();
			}
		}
		static void Main(string[] args)
		{
			using(ClassA a=new ClassA()) {
			}
			using (ClassA b = new ClassA())
			{
			}
		}
	}
}
