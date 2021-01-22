    public static class Houses
    {
        public static Houses<T> CreateFromElements<T>(params T[] initialElements)
        {
            return new Houses<T>(initialElements);
        }
    
        public Houses<T> CreateFromDefault<T>(int count, T defaultValue)
        {
            return new Houses<T>(count, defaultValue);
        }
    }
