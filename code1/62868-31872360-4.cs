    protected void UpdateProgressBar(ProgressBar prb, Int32 value, Int32 max)
    {
        if (max < 1)
            max = 1;
        if (value > max)
            value = max;
        // to avoid overflow when max*max exceeds Int32.MaxValue.
        // 0x8000 is a safe value a bit below the actual square root of Int32.MaxValue
        Int32 progressDivideValue = 1;
        while ((max / progressDivideValue) > 0x8000)
            progressDivideValue *= 256;
        max /= progressDivideValue;
        value /= progressDivideValue;
        // hacky mess, but it works...
        if (value < 1)
        {
            prb.Maximum = max;
            prb.Value = 0;
        }
        else
        {
            prb.Maximum = max * max;
            prb.Value = Math.Min(prb.Maximum, (max + 1));
            prb.Maximum = (int)((double)max / (double)value * max);
            prb.Value = max;
        }
    }
