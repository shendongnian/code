                if (BitConverter.IsLittleEndian)
                {
                    byte[] tempByteArray = new byte[2] { Item[5], Item[4] };
                    ushort num = BitConverter.ToUInt16(tempByteArray, 0);
                }
                else
                {
                    ushort num = BitConverter.ToUInt16(Item, 4);
                }
