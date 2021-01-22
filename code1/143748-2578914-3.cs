    public class MyBytes
    {
        public byte[] ByteArray { get; set; }
    }
    public static class MyExtensionMethods
    {
        // Notice the void return here...
        public static void MyClassExtension(this MyBytes buffer, byte[] header)
        {
            buffer.ByteArray = header;
        }
    }
