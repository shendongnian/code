    public class WindowsMessageListenerService : WinApiServiceBase
    {
        protected override void WndProc(Message message)
        {
            Debug.WriteLine(message.msg);
        }
    }
