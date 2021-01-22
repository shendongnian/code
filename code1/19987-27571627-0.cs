    using System.IO;
    using System.Text;
    public static class BinaryReaderExtension
    {
        public static string ReadLine(this BinaryReader reader)
        {
            if (reader.IsEndOfStream())
                return null;
    
            StringBuilder result = new StringBuilder();
    
            char character = reader.ReadChar();
            while(character != '\n' && !reader.IsEndOfStream())
            {
                //Do not add \r & \n to the string
                if(character != '\r' && character != '\n')
                    result.Append(character);
                character = reader.ReadChar();
            }
            return result.ToString();
        }
    
        public static bool IsEndOfStream(this BinaryReader reader)
        {
            return reader.BaseStream.Position == reader.BaseStream.Length; 
        }
    }
