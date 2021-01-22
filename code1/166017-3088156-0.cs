    public interface IInterface
    {
        event EventHandler Event;
        EventHandler Handler { get; set; }
    }
    public class Class : IInterface
    {
        public event EventHandler Event;
        public EventHandler Handler { get; set; }
    }
    public static class InterfaceExtensions
    {
        public static void DoSomething(this IInterface i)
        {
            i.Event += (o, e) => Console.WriteLine("Event raised and handled");
            i.Handler(i, new EventArgs());
        }
    }
