    public static class MyExtensions
    {
        public static int GetKeyValue(this int keyValue)
        {
    
            if (keyValue >= 48 && keyValue <= 57)
            {
                return keyValue - 48;
            }
            else if (keyValue >= 96 && keyValue <= 105)
            {
                return keyValue - 96;
            }
            else
            {
                return -1; // Not a number... do whatever...    }
    
            }
        }
    }
