    public static unsafe Byte[] GetBytes(String s)
    {
        Int32 length = s.Length * sizeof(Char);
        Byte[] bytes = new Byte[length];
        fixed (Char* pInput = s)
        fixed (Byte* pBytes = bytes)
        {
            Byte* source = (Byte*)pInput;
            Byte* destination = (Byte*)pBytes;
            if (length >= 16)
            {
                do
                {
                    *((Int64*)destination) = *((Int64*)source);
                    *((Int64*)(destination + 8)) = *((Int64*)(source + 8));
                    source += 16;
                    destination += 16;
                }
                while ((length -= 16) >= 16);
            }
            if (length > 0)
            {
                if ((length & 8) != 0)
                {
                    *((Int64*)destination) = *((Int64*)source);
                    source += 8;
                    destination += 8;
                }
                if ((length & 4) != 0)
                {
                    *((Int32*)destination) = *((Int32*)source);
                    source += 4;
                    destination += 4;
                }
                if ((length & 2) != 0)
                {
                    *((Int16*)destination) = *((Int16*)source);
                    source += 2;
                    destination += 2;
                }
                if ((length & 1) != 0)
                {
                    ++source;
                    ++destination;
                    destination[0] = source[0];
                }
            }
        }
        return bytes;
    }
