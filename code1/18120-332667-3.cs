        public static List<int> IndexOfSequence(this byte[] buffer, byte[] pattern, int startIndex)    
        {
           List<int> positions = new List<int>();
           int i = Array.IndexOf<byte>(buffer, pattern[0], startIndex);  
           while (i >= 0)  
           {
              byte[] segment = new byte[pattern.Length];
              Buffer.BlockCopy(buffer, i, segment, 0, pattern.Length);    
              if (segment.SequenceEqual<byte>(pattern))
                   positions.Add(i);
              i = Array.IndexOf<byte>(buffer, pattern[0], i + pattern.Length);
           }
           return positions;    
        }
