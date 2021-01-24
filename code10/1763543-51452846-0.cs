    public static class BaseExtensions
    {
        public static void ResetAll(Base[] baseArray)
        {
            foreach(var baseItem in baseArray)
            {
                baseItem.Reset();
            }
        }
    }
