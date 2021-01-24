        private byte[] StringToByteArray(string hex)
        {
            IList<byte> resultList = new List<byte>();
            foreach (char c in hex)
            {
                resultList.Add(Convert.ToByte(c));
            }
            return resultList.ToArray();
        }
