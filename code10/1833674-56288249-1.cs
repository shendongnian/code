//Copy Code and paste in C# Interactive Window
//(Existed in VS 2015+, "View->Other Window->C# Interactive")
//If you writen an http request and need a response test
//but the target API hasn't complated
//you can use this code to built a simple responder in C# Interactive window
//without to create a new webapi project for testing!
using System.Net;
var l = new HttpListener();
l.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
l.Prefixes.Add("http://localhost:8080/API/XXXX/");//ATTACTION: Uri should end with "/"
//more target url
var t = Task.Run(() =>
{
    Print("START!");
    l.Start();
    try
    {
        while (l.IsListening)
        {
            HttpListenerContext ctx = l.GetContext();//here for waiting
            Print(new StreamReader(ctx.Request.InputStream).ReadToEnd());
            ////Set Response here
            //ctx.Response.StatusCode = 200;
            //ctx.Response.OutputStream.Write("true".Select(c => (byte)c).ToArray(), 0, 4);
            ctx.Response.Close();//"Close" for return response
        }
    }
    catch { Print("STOP!"); }
});
//l.Stop(); //Call this method to stop HttpListener
Welcome to star/fork my repository<br/>
https://github.com/Flithor/CSharpInteractive_Mini_HttpRequest_Responder
