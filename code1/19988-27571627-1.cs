    using System.IO;
    using System.Text;
    public static class BinaryReaderExtension
    {
        public static string ReadLine(this BinaryReader reader)
        {
            if (reader.IsEndOfStream())
                return null;
    
            StringBuilder result = new StringBuilder();
            char character;
            while(!reader.IsEndOfStream() && (character = reader.ReadChar()) != '\n')
                if (character != '\r' && character != '\n')
                    result.Append(character);
          
            return result.ToString();
        }
    
        public static bool IsEndOfStream(this BinaryReader reader)
        {
            return reader.BaseStream.Position == reader.BaseStream.Length; 
        }
    }
