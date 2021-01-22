    class someclass {
        public static void doIp(byte[] data)
        {
            uint j, k; // these are just counters, so uint is fine
            byte val;
            byte[] buf = new byte[8];  // syntax changed here
            byte p;                    // you end up using p simply as an offset from buf
            byte i = 8;
            for(i=0; i<8; i++)
            {
                val = data[i];
                p = 3;
                j = 4;
                do
                {
                    for(k=0; k<=4; k+=4)
                    {
                        buf[p+k] >>= 1;
                        if((val & 1) != 0) buf[p+k] |= 0x80; // must test against 0 explicitly in C#
                        val >>= 1;
                    }
                    p--;
                } while(--j != 0); // must test against 0 explicitly in C#
            }
            Array.Copy(buf, data, 8);
        }
    }
