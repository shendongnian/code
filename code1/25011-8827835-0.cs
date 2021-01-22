    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text.RegularExpressions;
    using System.Threading;
    class TelnetTest
    {
    
        static void Main(string[] args)
        {
            TelnetTest tt = new TelnetTest();
        tt.tcpClient = new TcpClient("myserver", 23);
        tt.ns = tt.tcpClient.GetStream();
        tt.connectHost("admin", "admin");
        tt.sendCommand();
        tt.tcpClient.Close();
    }
    public void connectHost(string user, string passwd) {
        bool i = true;
        while (i)
        {
            Console.WriteLine("Connecting.....");
            Byte[] output = new Byte[1024];
            String responseoutput = String.Empty;
            Byte[] cmd = System.Text.Encoding.ASCII.GetBytes("\n");
            ns.Write(cmd, 0, cmd.Length);
            Thread.Sleep(1000);
            Int32 bytes = ns.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            Console.WriteLine("Responseoutput: " + responseoutput);
            Regex objToMatch = new Regex("login:");
            if (objToMatch.IsMatch(responseoutput)) {
               cmd = System.Text.Encoding.ASCII.GetBytes(user + "\r");
               ns.Write(cmd, 0, cmd.Length);
            }
            Thread.Sleep(1000);
            bytes = ns.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            Console.Write(responseoutput);
            objToMatch = new Regex("Password");
            if (objToMatch.IsMatch(responseoutput))
            {
                cmd = System.Text.Encoding.ASCII.GetBytes(passwd + "\r");
                ns.Write(cmd, 0, cmd.Length);
            }
            Thread.Sleep(1000);
            bytes = ns.Read(output, 0, output.Length);
            responseoutput = System.Text.Encoding.ASCII.GetString(output, 0, bytes);
            Console.Write("Responseoutput: " + responseoutput);
            objToMatch = new Regex("#");
            if (objToMatch.IsMatch(responseoutput))
            {
                i = false;
            }
        }
        Console.WriteLine("Just works");
    }
    }
