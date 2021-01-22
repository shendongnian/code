    private  int Asc(char String)
            {
                int int32 = Convert.ToInt32(String);
                if (int32 < 128)
                    return int32;
                try
                {
                    Encoding fileIoEncoding = Encoding.Default;
                    char[] chars = new char[1] { String };
                    if (fileIoEncoding.IsSingleByte)
                    {
                        byte[] bytes = new byte[1];
                        fileIoEncoding.GetBytes(chars, 0, 1, bytes, 0);
                        return (int)bytes[0];
                    }
                    byte[] bytes1 = new byte[2];
                    if (fileIoEncoding.GetBytes(chars, 0, 1, bytes1, 0) == 1)
                        return (int)bytes1[0];
                    if (BitConverter.IsLittleEndian)
                    {
                        byte num = bytes1[0];
                        bytes1[0] = bytes1[1];
                        bytes1[1] = num;
                    }
                    return (int)BitConverter.ToInt16(bytes1, 0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
`
