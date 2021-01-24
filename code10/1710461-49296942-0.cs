    public static byte[] getEncodedMessage(byte[] bytesRaw)
        {
            List<byte> bytesFormatted = new List<byte>();
            bytesFormatted.Add(129);
            int indexStartRawData = -1; // it doesn't matter what value is
                                        // set here - it will be set now:
            if (bytesRaw.LongLength <= 125)
            {
                bytesFormatted.Add(Convert.ToByte(bytesRaw.LongLength));
                indexStartRawData = 2;
            }
            else if (bytesRaw.LongLength >= 126 && bytesRaw.LongLength <= 65535)
            {
                bytesFormatted.Add(126);
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength >> 8) & 255));
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength) & 255));
                indexStartRawData = 4;
            }
            else
            {
                bytesFormatted.Add(127);
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength >> 56) & 255));
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength >> 48) & 255));
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength >> 40) & 255));
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength >> 32) & 255));
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength >> 24) & 255));
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength >> 16) & 255));
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength >> 8) & 255));
                bytesFormatted.Add(Convert.ToByte((bytesRaw.LongLength) & 255));
                indexStartRawData = 10;
            }
            // put raw data at the correct index
            bytesFormatted.InsertRange(indexStartRawData, bytesRaw);
            return bytesFormatted.ToArray();
        }
