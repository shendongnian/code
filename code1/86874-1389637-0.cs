        public static bool ArraysEqual(byte[] b1, byte[] b2)
        {
            unsafe
            {
                if (b1.Length != b2.Length)
                    return false;
                int n = b1.Length;
                fixed (byte *p1 = b1, p2 = b2)
                {
                    byte *ptr1 = p1;
                    byte *ptr2 = p2;
                    while (n-- > 0)
                    {
                        if (*ptr1++ != *ptr2++)
                            return false;
                    }
                }
                return true;
            }
        }
