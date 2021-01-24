    [StructLayout(LayoutKind.Explicit)]
        public unsafe struct InfoDetails
        {
            [FieldOffset(0x14)]
            public fixed byte Name[50];
            
            public string test
            {
                get
                {
                    List<byte> clearBytes = new List<byte>();
                    fixed (byte* namePtr = Name)
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            if (namePtr[i] == 0x0 && namePtr[i + 1] == 0x0)
                            {
                                break;
                            }
                            clearBytes.Add(namePtr[i]);
                        }
                        if (clearBytes.Count() % 2 != 0)
                        {
                            clearBytes.Add(0x00);
                        }
                        return Encoding.Unicode.GetString(clearBytes.ToArray());
                    }
                }
            }
            
        }
