        public static long GetCommitCharge()
        {
            var p = new System.Diagnostics.PerformanceCounter("Memory", "Committed Bytes");
            return p.RawValue;
        }
