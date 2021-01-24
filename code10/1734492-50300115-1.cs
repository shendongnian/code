		public interface INotificationChannel
		{
		    Task Send(Message message);
		}
		public interface INotificationChannelEngine
		{
		    void RegisterNotificationChannel(INotificationChannel channel, MessageType messageType);
		    void Process(Message message);
		}
		public class Message
		{
		    public MessageType MessageType;
		    public string Text;
		}
		public class MailNotificationChannel : INotificationChannel
		{
		    public async Task Send(Message message)
		    {
		        //to be implemented
		    }
		}
		public class FileNotificationChannel : INotificationChannel
		{
		    public string Path = "Some filepath";
		    public async Task Send(Message message)
		    {
		        Logger.Log(message.Text, Path);
		        await Task.Delay(0);
		    }
		}
		public class ConsoleNotificationChannel : INotificationChannel
		{
		    public string Path;
		    public async Task Send(Message message)
		    {
		        Console.WriteLine(message.Text);
		        await Task.Delay(0);
		    }
		}
		public enum MessageType
		{
		    // using powers of 2 here so we can bitmask and use Enum.HasFlag
		    MessageType1 = 1,
		    MessageType2 = 2,
		    SomeMailableMessageType = 4, // Don't actually name it this specifically but for demonstration purposes...
		    MessageType4 = 8,
		    Global = 16
		}
		public class NotificationChannelEngine : INotificationChannelEngine
		{
		    private readonly IDictionary<INotificationChannel, MessageType> _notificationChannels;
		    public NotificationChannelEngine()
		    {
		        _notificationChannels = new Dictionary<INotificationChannel, MessageType>();
		    }
		    public void RegisterNotificationChannel(INotificationChannel channel, MessageType messageType)
		    {
		        _notificationChannels.Add(channel, messageType);
		    }
		    public void Process(Message message)
		    {
		        foreach (var channel in _notificationChannels.Where(channel => message.MessageType == MessageType.Global || channel.Value.HasFlag(message.MessageType)))
		            channel.Key.Send(message);
		    }
		}
		public class Program
		{
		    private static readonly NotificationChannelEngine NotificationChannel = new NotificationChannelEngine();
		    public static void Main()
		    {
		        //shared variables
		        // Common.Log = new Database().GetLogPath();
		        // Common.IsDebug = new Database().GetisDebug();
		        //registering specific channels
		        // register file notification to subscribe to message type 1
		        NotificationChannel.RegisterNotificationChannel(new FileNotificationChannel() { Path = "mypath" }, MessageType.MessageType1);
		        // register console notification to subscribe to message types 2 and 4
		        NotificationChannel.RegisterNotificationChannel(new ConsoleNotificationChannel(), MessageType.MessageType2 | MessageType.MessageType4);
		        // register mail notification to subscribe to a mailable type (name this more generically but I want this example to be clear)
		        NotificationChannel.RegisterNotificationChannel(new MailNotificationChannel(), MessageType.SomeMailableMessageType);
		        new Runner(NotificationChannel).Run(DateTime.Now.AddDays(-1)).Wait();
		    }
		}
		internal class Runner
		{
		    public INotificationChannelEngine NotificationChannelEngine;
		    public Runner(INotificationChannelEngine notificationengine)
		    {
		        NotificationChannelEngine = notificationengine;
		    }
		    public async Task Run(DateTime date)
		    {
		        try
		        {
		            //some operation 1
		            // This will send to all channels
		            NotificationChannelEngine.Process(new Message() { Text = "Some log", MessageType = MessageType.Global });
		            //some operation 2
		            // This will send only to channels subscribed for MessageType1 (just the file notification)
		            NotificationChannelEngine.Process(new Message() { Text = "Some log 2", MessageType = MessageType.MessageType1 });
		            //some operation 3
		            //i would like exclude mail from here
		            // This will send to all channels registered for event types other than SomeMailableMessageType (but not excluding them depending on how they are registered)
		            NotificationChannelEngine.Process(new Message() { Text = "Some log 2", MessageType = MessageType.MessageType1 | MessageType.MessageType2 | MessageType.MessageType4 });
		            //now resume mail again
		            //some operation 4
		            // This will send to all channels again
		            NotificationChannelEngine.Process(new Message() { Text = "Some log 2", MessageType = MessageType.Global });
		        }
		        catch { /* Do something here */ }
		    }
		}
		public sealed class Logger
		{
		    public static void Log(string msg, string filePath)
		    {
		        // your original log implementation here
		    }
		}
