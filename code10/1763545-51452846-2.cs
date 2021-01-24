    public static class BaseExtensions
    {
        public static void ResetAll(this Base[] baseArray)
        {
            foreach(var baseItem in baseArray)
            {
                baseItem.Reset();
            }
        }
    }
