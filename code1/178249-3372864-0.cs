    public static IEnumerable<float> FloatRange(float min, float max, float step)
    {
        for (float value = min; value <= max; value += step)
        {
            yield return value;
        }
    }
