        public void SetTagData(string _data)
        {
            string data = _data;
            byte[] ba = Encoding.Default.GetBytes(data);
            string hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            var blockStart = 0;
            try
            {
                _reader.Protocol("s");
                for(var count = 0; count < 16; count++)  
                {
                    var byteList = new List<byte>();
                    byte[] datablockKey = ConvertHelpers.ConvertHexStringToByteArray(count.ToString("X2"));
                    byteList.AddRange(datablockKey);
                    for (var innerCount = 0; innerCount < 4; innerCount++)
                    {
                        var block = String.Empty;
                        if (!String.IsNullOrEmpty(hexString.Substring(blockStart, 2)))
                        {
                            block = hexString.Substring(blockStart, 2);
                        }
                        else
                        {
                            block = "20";
                        }
                        byte[] datablockValue = ConvertHelpers.ConvertHexStringToByteArray(block);
                        byteList.AddRange(datablockValue);
                        blockStart += 2;
                    }
                    _reader.Protocol("wb", byteList.ToArray());
                }
            }
            catch (Exception)
            {
            }
        }
