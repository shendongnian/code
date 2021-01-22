    private void cmd_Click()
    {
       int i, a = 10;
       Random r = new Random();
       for(i = 1; i <= a; i++)
       {
           List<byte> file = new List<byte>();
           file.AddRange(System.IO.File.ReadAllBytes("txt"));
           file.AddRange(BitConverter.GetBytes((float)r.NextDouble()));
           System.IO.File.WriteAllBytes(String.Format(@"txtpath\{0}txtname", i), file.ToArray());
       }
    }
