    namespace DelegatesAndEvents
    {
        public class MyEventArgs : EventArgs
        {
            public string Message { get; set; }
            public MyEventArgs(string message) { Message = message; }
        }
    
        delegate void TwoWayCallback(string message);
        delegate void TwoWayEventHandler(object sender, MyEventArgs eventArgs);
    
        interface ITwoWay
        {
            void CallThis(TwoWayCallback callback);
    
            void Trigger(string message);
            event TwoWayEventHandler TwoWayEvent;
        }
    
        class Talkative : ITwoWay
        {
            public void CallThis(TwoWayCallback callback)
            {
                callback("Delegate invoked.");
            }
    
            public void Trigger(string message)
            {
                TwoWayEvent.Invoke(this, new MyEventArgs(message));
            }
    
            public event TwoWayEventHandler TwoWayEvent;
        }
    
        class Program
        {
            public static void MyCallback(string message)
            {
                Console.WriteLine(message);
            }
    
            public static void OnMyEvent(object sender, MyEventArgs eventArgs)
            {
                Console.WriteLine(eventArgs.Message);
            }
    
            static void Main(string[] args)
            {
                Talkative talkative = new Talkative();
    
                talkative.CallThis(MyCallback);
    
                talkative.TwoWayEvent += new TwoWayEventHandler(OnMyEvent);
                talkative.Trigger("Event fired with this message.");
    
                Console.ReadKey();
            }
        }
    }
