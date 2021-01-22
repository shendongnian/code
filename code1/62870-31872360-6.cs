    protected void UpdateProgressBar(ProgressBar prb, Int64 value, Int64 max)
    {
        if (max < 1)
            max = 1;
        if (value > max)
            value = max;
        Int32 finalmax = 1;
        Int32 finalvalue = 0;
        if (value > 0)
        {
            if (max > 0x8000)
            {
                // to avoid overflow when max*max exceeds Int32.MaxValue.
                // 0x8000 is a safe value a bit below the actual square root of Int32.MaxValue
                Int64 progressDivideValue = 1;
                while ((max / progressDivideValue) > 0x8000)
                    progressDivideValue *= 0x10;
                finalmax = (Int32)(max / progressDivideValue);
                finalvalue = (Int32)(value / progressDivideValue);
            }
            else
            {
                // Upscale values to increase precision, since this is all integer division
                // Again, this can never exceed 0x8000.
                Int64 progressMultiplyValue = 1;
                while ((max * progressMultiplyValue) < 0x800)
                    progressMultiplyValue *= 0x10;
                finalmax = (Int32)(max * progressMultiplyValue);
                finalvalue = (Int32)(value * progressMultiplyValue);
            }
        }
        if (finalvalue <= 0)
        {
            prb.Maximum = (Int32)Math.Min(Int32.MaxValue, max);
            prb.Value = 0;
        }
        else
        {
            // hacky mess, but it works...
            // Will pretty much empty the bar for a split second, but this is normally never visible.
            prb.Maximum = finalmax * finalmax;
            // Makes sure the value will DEcrease in the last operation, to ensure the animation is skipped.
            prb.Value = Math.Min(prb.Maximum, (finalmax + 1));
            // Sets the final values.
            prb.Maximum = (finalmax * finalmax) / finalvalue;
            prb.Value = finalmax;
        }
    }
