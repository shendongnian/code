        protected void UpdateProgressBar(ProgressBar prb, Int32 value, Int32 max)
        {
            if (value < 1)
            {
                prb.Maximum = max;
                prb.Value = 0;
            }
            else
            {
                // to avoid overflow when max*max exceeds Int32.MaxValue.
                // 0x8000 is a safe value a bit below the actual square root of Int32.MaxValue
                Int32 progressDivideValue = 1;
                while ((max / progressDivideValue) > 0x8000)
                    progressDivideValue *= 256;
                max /= progressDivideValue;
                value /= progressDivideValue;
                prb.Maximum = max * max;
                prb.Value = Math.Min(prb.Maximum, (max + 1));
                prb.Maximum = (int)((double)max / (double)value * max);
                prb.Value = max;
            }
            Thread.Sleep(20);
        }
