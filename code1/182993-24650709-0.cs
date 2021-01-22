        public static IPAddress AddOne(this IPAddress ipAddress)
        {
            byte[] data = ipAddress.GetAddressBytes();
            IncrementByOneFromLeft(data, data.Length - 1);
            return new IPAddress(data);
        }
        private static void IncrementByOneFromLeft(byte[] data, int index)
        {
            if (index < 0)
                return;
            
            if (data[index] < byte.MaxValue)
                data[index] += 1;
            else
            {
                data[index] = 0;
                IncrementByOneFromLeft(data, index - 1);
            }
        }
