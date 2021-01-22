        private static bool TryParseHex(string hex, out UInt32 result)
        {
            result = 0;
            if (hex == null)
            {
                return false;
            }
            try
            {
                result = Convert.ToUInt32(hex, 16);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
