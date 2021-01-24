    public static class Extensions
    {
        public static bool IsAllFalse(this BitArray bitArray)
        {
            for (int i = 0; i < bitArray.Length; i++)
            {
                if (bitArray[i] == true)
                    return false;
            }
            return true;
        }
    }
