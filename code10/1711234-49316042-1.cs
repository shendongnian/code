    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using System.IO.Pipes;
    using System.Text;
    using System.Threading;
    
    public class Bob
    {
      static void Main()
      {
        var svr = new NamedPipeServerStream("boris", PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte);
        var helper = Task.Run(() =>
        {
          var clt = new NamedPipeClientStream("localhost", "boris", PipeDirection.InOut, PipeOptions.Asynchronous);
          clt.Connect();
          var inBuff = new byte[256];
          var read = clt.ReadAsync(inBuff, 0, inBuff.Length);
          var msg = Encoding.UTF8.GetBytes("Hello!");
          var write = clt.WriteAsync(msg, 0, msg.Length);
          Task.WaitAll(read, write);
          var cltMsg = Encoding.UTF8.GetString(inBuff, 0, read.Result);
          Console.WriteLine("Client got message: {0}", cltMsg);
        });
        svr.WaitForConnection();
        var srvBuff = new byte[256];
        var srvL = svr.Read(srvBuff, 0, srvBuff.Length);
        var svrMsg = Encoding.UTF8.GetString(srvBuff, 0, srvL);
        Console.WriteLine("Server got message: {0}", svrMsg);
        var response = Encoding.UTF8.GetBytes("We're done now");
        svr.Write(response, 0, response.Length);
        helper.Wait();
        Console.WriteLine("It's all over");
        Console.ReadLine();
      }
    }
