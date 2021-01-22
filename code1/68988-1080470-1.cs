        static void Main(string[] args)
        {
            byte[] data;
            string path = @"C:\Windows\System32\notepad.exe";
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                data = StreamToByteArray(fs);
            }
            Debug.Assert(data.Length > 0);
            Debug.Assert(new FileInfo(path).Length == data.Length); 
        }
