        public static int Asc(char String)
        {
            int num;
            byte[] numArray;
            int num1 = Convert.ToInt32(String);
            if (num1 >= 128)
            {
                try
                {
                    Encoding fileIOEncoding = Encoding.Default;
                    char[] str = new char[] { String };
                    if (!fileIOEncoding.IsSingleByte)
                    {
                        numArray = new byte[2];
                        if (fileIOEncoding.GetBytes(str, 0, 1, numArray, 0) != 1)
                        {
                            if (BitConverter.IsLittleEndian)
                            {
                                byte num2 = numArray[0];
                                numArray[0] = numArray[1];
                                numArray[1] = num2;
                            }
                            num = BitConverter.ToInt16(numArray, 0);
                        }
                        else
                        {
                            num = numArray[0];
                        }
                    }
                    else
                    {
                        numArray = new byte[1];
                        fileIOEncoding.GetBytes(str, 0, 1, numArray, 0);
                        num = numArray[0];
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            else
            {
                num = num1;
            }
            return num;
        }
       
 
