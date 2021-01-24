    public static class ExtentionCounter
    {
        public static void Increment(this Counter cnt)
        {
            cnt.Value++;
        }
    } 
