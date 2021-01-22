    public interface IMessageReader()
    {
        ONIXMessage Read(string xml);
    }
    
    public static class ONIXMessageFactory
    {
        private static IList<IMessageReader> readers = new List<IMessageReader>();
    
        public static ONIXMessage CreateMessage(string xml)
        {
          var reader = GetReader(xml);
          return reader.Read(xml);
        }
        
        public static IMessageReader GetReader(string xml)
        {
          // Somehow identify which reader would be required.
        }
    }
