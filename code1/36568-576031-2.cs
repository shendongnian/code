        public short changeBytes(ref long ptr, ref int arraysize)
        {
            try
            {
                IntPtr interopPtr = new IntPtr(ptr);                
                testservice.ByteArray bytes = new testservice.ByteArray();
                byte[] somebytes = new byte[arraysize];
                Marshal.Copy(interopPtr, somebytes, 0, arraysize);
                bytes.theArray = somebytes;
                CalculatorClient client = generateClient();
                client.takeArray(ref bytes);
                client.Close();
                if (arraysize < bytes.theArray.Length)
                {
                    interopPtr = Marshal.ReAllocCoTaskMem(interopPtr, bytes.theArray.Length);//TODO : throws an exception if fails... deal with it
                }
                Marshal.Copy(bytes.theArray, 0, interopPtr, bytes.theArray.Length);
                ptr = interopPtr.ToInt64();
                arraysize = bytes.theArray.Length;
                //TODO : do we need to free IntPtr? check all code for memory leaks... check for successful allocation
            }
            catch(Exception e)
            {
                return 3;
            }
            return 2;
        }
