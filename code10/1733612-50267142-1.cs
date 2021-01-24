    public class SpnCustomListener:TextWriterTraceListener
    {
        private INetLog log = ObjectFactory.GetInstance< INetLog >();
        private static Object slLock = new Object();
        private List <string> sl = null;
