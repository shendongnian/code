    public static class RandomEx
    {
        public static string NextString(this Random r, int size)
        {
            var data = new byte[size];
            for (int i = 0; i < data.Length; i++)
            {
                // All ASCII symbols: printable and non-printable
                // data[i] = (byte)r.Next(0, 128);
                // Only printable ASCII
                data[i] = (byte)r.Next(32, 127);               
            }
            var encoding = new ASCIIEncoding();
            return encoding.GetString(data);
        }
    }
