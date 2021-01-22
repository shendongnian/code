        public struct mytest
        {
            public int myint;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public int[] ptime;
        }
        public static void SwapIt(Type type, byte[] recvbyte, int offset)
        {
            foreach (System.Reflection.FieldInfo fi in type.GetFields())
            {
                int index = Marshal.OffsetOf(type, fi.Name).ToInt32() + offset;
                if (fi.FieldType == typeof(int))
                {
                    Array.Reverse(recvbyte, index, sizeof(int));
                }
                else if (fi.FieldType == typeof(float))
                {
                    Array.Reverse(recvbyte, index, sizeof(float));
                }
                else if (fi.FieldType == typeof(double))
                {
                    Array.Reverse(recvbyte, index, sizeof(double));
                }
                else
                {
                    // Maybe we have an array
                    if (fi.FieldType.IsArray)
                    {
                        // Check for MarshalAs attribute to get array size
                        object[] ca = fi.GetCustomAttributes(false);
                        if (ca.Count() > 0 && ca[0] is MarshalAsAttribute)
                        {
                            int size = ((MarshalAsAttribute)ca[0]).SizeConst;
                            // Need to use GetElementType to see that int[] is made of ints
                            if (fi.FieldType.GetElementType() == typeof(int))
                            {
                                for (int i = 0; i < size; i++)
                                {
                                    Array.Reverse(recvbyte, index + (i * sizeof(int)), sizeof(int));
                                }
                            }
                            else if (fi.FieldType.GetElementType() == typeof(float))
                            {
                                for (int i = 0; i < size; i++)
                                {
                                    Array.Reverse(recvbyte, index + (i * sizeof(float)), sizeof(float));
                                }
                            }
                            else if (fi.FieldType.GetElementType() == typeof(double))
                            {
                                for (int i = 0; i < size; i++)
                                {
                                    Array.Reverse(recvbyte, index + (i * sizeof(double)), sizeof(double));
                                }
                            }
                            else
                            {
                                // An array of something else?
                                Type t = fi.FieldType.GetElementType();
                                int s = Marshal.SizeOf(t);
                                for (int i = 0; i < size; i++)
                                {
                                    SwapIt(t, recvbyte, index + (i * s));
                                }
                            }
                        }
                    }
                    else
                    {
                        SwapIt(fi.FieldType, recvbyte, index);
                    }
                }
            }
        }
