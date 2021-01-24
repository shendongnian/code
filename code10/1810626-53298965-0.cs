        enum READ_WRITE
        {
            READ,
            WRITE
        }
        public class Test
        {
            private readonly object readWritelock = new object();
            public object ReadWrite(READ_WRITE readWrite, object data)
            {
                object returnValue = 0;
                lock (readWritelock)
                {
                    switch (readWrite)
                    {
                        case READ_WRITE.READ :
                            //add you read code here
                            break;
                        case READ_WRITE.WRITE :
                            //add your write code here
                            break;
                    }
                }
                return returnValue;
            }
        }
