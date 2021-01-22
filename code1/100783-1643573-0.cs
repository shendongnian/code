        public string ReadBytes(byte[] rawData)
        {
            //the encoding will prolly be the default of your system
            return Encoding.Default.GetString(rawData);
        }
