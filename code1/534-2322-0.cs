    public virtual bool SetMessageBytes(byte[] message)
        {
            MemberInfo[] members = FormatterServices.GetSerializableMembers(this.GetType());
            object[] values = FormatterServices.GetObjectData(this, members);
            int j = 0;
            for (int i = 0; i < members.Length; i++)
            {
                string[] var = members[i].ToString().Split(new char[] { ' ' });
                switch (var[0])
                {
                    case "UInt32":
                        values[i] = (UInt32)((message[j] << 24) + (message[j + 1] << 16) + (message[j + 2] << 8) + message[j + 3]);
                        j += 4;
                        break;
                    case "UInt16":
                        values[i] = (UInt16)((message[j] << 8) + message[j + 1]);
                        j += 2;
                        break;
                    case "Byte":
                        values[i] = (byte)message[j++];
                        break;
                    case "UInt32[]":
                        if (values[i] != null)
                        {
                            int len = ((UInt32[])values[i]).Length;
                            byte[] b = new byte[len * 4];
                            Array.Copy(message, j, b, 0, len * 4);
                            Array.Copy(Utilities.ByteArrayToUInt32Array(b), (UInt32[])values[i], len);
                            j += len * 4;
                        }
                        break;
                    case "Byte[]":
                        if (values[i] != null)
                        {
                            int len = ((byte[])values[i]).Length;
                            Array.Copy(message, j, (byte[])(values[i]), 0, len);
                            j += len;
                        }
                        break;
                    default:
                        throw new Exception("ByteExtractable::SetMessageBytes Unsupported Type: " + var[1] + " is of type " +  var[0]);
                }
            }
            FormatterServices.PopulateObjectMembers(this, members, values);
            return true;
        }
