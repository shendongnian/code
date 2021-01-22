        static IEnumerable<byte> GetBytes()
        {
            byte[] bytes = new byte[10];
            // simple initialization of the array, replace with your I/O here if blocking
            for (byte x = 0; x < bytes.Length; x++)
            {
                bytes[x] = x;
            }
            // this generates the IEnumerable<byte>.
            // Replace "bytes[x]" with an I/O operation
            // that returns one byte if you want to allow data to flow as available through
            // the IEnumerable<byte>
            for (int x = 0; x < bytes.Length; x++)
            {
                yield return bytes[x];
            }
        }
