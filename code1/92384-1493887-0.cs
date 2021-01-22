    public static class MathUtil
    {
        public static float Clamp(this float value, float min, float max)
        {
            return Math.Min(max, Math.Max(min, value));
        }
    }
