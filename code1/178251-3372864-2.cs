    public static IEnumerable<float> FloatRange(float min, float max, float step)
    {
        for (int i = 0; i < int.MaxValue; i++)
        {
            float value = min + step * i;
            if (value > max)
            {
                break;
            }
            yield return value;
        }
    }
