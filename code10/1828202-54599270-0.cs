    using QuickFix;
    public class MyApplication : MessageCracker, IApplication
    {
        public void FromApp(Message msg, SessionID sessionID)
        {
            Crack(msg, sessionID);
        }
        //...
    }
