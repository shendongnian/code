    public class NumberReader 
    {
        StreamReader reader;
    
        public NumberReader(StreamReader reader)
        {
            this.reader = reader;
        }
    
        public UInt64 ReadUInt64()
        {
            UInt64 result = 0;
    
            while (!reader.EndOfStream)
            {
                int c = reader.Read();
                if (char.IsDigit((char) c))
                {
                    result = 10 * result + (UInt64) (c - '0');
                }
                else
                {
                    break;
                }
            }
    
            return result;
        }
    }
