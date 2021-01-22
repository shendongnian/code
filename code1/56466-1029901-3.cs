        public static void PrintHash(TextWriter op, byte[] hash)
        {
            foreach (byte b in hash)
            {
                op.Write("{0:X2}", b);
            }
        }
