    public void ReadObjectAsync<T>(string filename)
        {
            ThreadStart ts = delegate() { ReadObject<T>(filename); };
            Thread th = new Thread(ts);
            th.IsBackground = true;
            th.Start();
        }
        private void ReadObject<T>(string filename)
        {
            // Deserializes a file to a type.
        } 
