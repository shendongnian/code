    class Program
    {
       static void Main(string[] args)
       {
           dynamic d = new ExpandoObject();
           // Initialize the event to null (meaning no handlers)
           d.MyEvent = null;
           // Add some handlers
           d.MyEvent += new EventHandler(OnMyEvent);
           d.MyEvent += new EventHandler(OnMyEvent2);
           // Fire the event
           EventHandler e = d.MyEvent;
           e?.Invoke(d, new EventArgs());
       }
       static void OnMyEvent(object sender, EventArgs e)
       {
           Console.WriteLine("OnMyEvent fired by: {0}", sender);
       }
       static void OnMyEvent2(object sender, EventArgs e)
       {
           Console.WriteLine("OnMyEvent2 fired by: {0}", sender);
       }
    }
