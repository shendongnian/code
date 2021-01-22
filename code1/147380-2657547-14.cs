    public void InvertSignature(ref byte[] original, 
        bool invertHorizontal, bool invertVertical)
    {
        short w = BitConverter.ToInt16(original, 0);
        short h = BitConverter.ToInt16(original, 2);
        int i = 4;
        while (i < original.Length)
        {
            if (invertHorizontal)
            {
                if (w < 256)
                {
                    if (original[i] != 0)
                    {
                        original[i] = (byte)w - original[i] - 1;
                    }
                    i++;
                }
                else
                {
                    short val = BitConverter.ToInt16(original, i);
                    if (val != 0)
                    {
                        val = w - val - 1;
                        byte[] valbytes = BitConverter.GetBytes(val);
                        Buffer.BlockCopy(valbytes, 0, original, i, 2);
                    }
                    i += 2;
                }
            }
            else
            {
                i += (w < 256) ? 1 : 2;
            }
            if (invertVertical)
            {
                if (h < 256)
                {
                    if (original[i] != 0)
                    {
                        original[i] = (byte)h - original[i] - 1;
                    }
                    i++;
                }
                else
                {
                    short val = BitConverter.ToInt16(original, i);
                    if (val != 0)
                    {
                        val = h - val - 1;
                        byte[] valbytes = BitConverter.GetBytes(val);
                        Buffer.BlockCopy(valbytes, 0, original, i, 2);
                    }
                    i += 2;
                }
            }
            else
            {
                i += (h < 256) ? 1 : 2;
            }
        }
    }
