using ...
using ...
namespace MyWCFNamespace
{
class Program {
static void Main(string[] args){
//instantiate the event receiver
Consumer c = new Consumer();
// instantiate the event source
WCFService svc = new WCFService();
svc.WCFEvent += new SomeEventHandler(c.ProcessTheRaisedEvent);
using(ServiceHost host = new ServiceHost(svc))
{
  host.Open();
  Console.Readline();
}
}
}
public class Consumer()
{
public void ProcessTheRaisedEvent(object sender, MyEventArgs e)
{
Console.WriteLine(e.From.toString() + "\t" + e.To.ToString());
}
}
}
namespace MyWCFNamespace
{
public delegate void SomeEventHandler(object sender,MyEventArgs e)
[ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
public class WCFService : IWCFService 
{
public event SomeEventHandler WCFEvent;
public void someMethod(Message message)
{
MyEventArgs e = new MyEventArgs(message);
OnWCFEvent(e);
}
public void OnWCFEvent(MyEventArgs e)
{
SomeEventHandler handler = WCFEvent;
if(handler!=null)
{
 handler(this,e);
}
}
// to do 
// Implement WCFInterface methods here
}
public class MyEventArgs:EventArgs
{
private Message _message;
public MyEventArgs(Message message) 
{
this._message=message;
}
}
public class Message
{
string _from;
string _to;
public string From {get{return _from;} set {_from=value;}}
public string To {get{return _to;} set {_to=value;}}
public Message(){}
public Message(string from,string to)
this._from=from;
this._to=to;
}
}
You can define your WCF service with InstanceContextMode=InstanceContextMode.Single.
TestService svc = new TestService();
svc.SomeEvent += new MyEventHandler(receivingObject.OnSomeEvent);
ServiceHost host = new ServiceHost(svc);
host.Open();
[ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)] // so that a single service instance is created
    public class TestService : ITestService
    {
        public event MyEventHandler SomeEvent;
        ...
        ...
    }
