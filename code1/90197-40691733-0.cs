        public string READS()
        {
            byte[] buf = new byte[CLI.Available];//set buffer
            CLI.Receive(buf);//read bytes from stream
            string line = UTF8Encoding.UTF8.GetString(buf);//get string from bytes
            return line;//return string from bytes
        }
        public void WRITES(string text)
        {
            byte[] buf = UTF8Encoding.UTF8.GetBytes(text);//get bytes of text
            CLI.Send(buf);//send bytes
        }
