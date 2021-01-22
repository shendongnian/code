        public static IPAddress AddOne(this IPAddress ipAddress)
        {
            byte[] data = ipAddress.GetAddressBytes();
            IncrementByOneFromRight(data, data.Length - 1);
            return new IPAddress(data);
        }
        private static void IncrementByOneFromRight(byte[] data, int index)
        {
            if (index < 0)
                return;
            
            if (data[index] < byte.MaxValue)
                data[index] += 1;
            else
            {
                data[index] = 0;
                IncrementByOneFromRight(data, index - 1);
            }
        }
