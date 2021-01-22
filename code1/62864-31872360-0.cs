        protected void UpdateProgressBar(ProgressBar prb, Int32 value, Int32 max)
        {
            if (value < 1)
            {
                prb.Maximum = max;
                prb.Value = 0;
            }
            else
            {
                prb.Maximum = max * max;
                prb.Value = max + 1;
                prb.Maximum = (int)((double)max / (double)value * max);
                prb.Value = max;
            }
            Thread.Sleep(20);
        }
