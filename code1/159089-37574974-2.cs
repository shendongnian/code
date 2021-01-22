    /// <summary>
    /// Generate a BigInteger given a Guid. Returns a number from 0 to 2^128
    /// 0 to 340,282,366,920,938,463,463,374,607,431,768,211,456
    /// </summary>
        public BigInteger GuidToBigInteger(Guid guid)
        {
            BigInteger l_retval = 0;
            byte[] ba = guid.ToByteArray();
            int i = ba.Count();
            foreach (byte b in ba)
            {
                l_retval += b * BigInteger.Pow(256, --i);
            }
            return l_retval;
        }
