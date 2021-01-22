    public static class RandomEx
    {
        public static string NextString(this Random r, int size)
        {
            var data = new byte[size];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)r.Next(0, 128);
            }
            var encoding = new ASCIIEncoding();
            return encoding.GetString(data);
        }
    }
