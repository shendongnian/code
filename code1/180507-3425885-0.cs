    using System;
    using System.Net;
    using System.Net.Sockets;
    
    public class test {
    	public static void Main(String[] args) {
    		IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
    		IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 8888);
    		TcpListener tcpServer = new TcpListener(ipLocalEndPoint);
    		tcpServer.Start(); // Without this line there is exception
    		var _TCPClient = tcpServer.AcceptTcpClient();
    	}
    }
