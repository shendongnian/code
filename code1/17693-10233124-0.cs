    public class ProcessorUsage
    {
        const float sampleFrequencyMillis = 1000;
    
        protected object syncLock = new object();
        protected PerformanceCounter counter;
        protected float lastSample;
        protected DateTime lastSampleTime;
    
        /// <summary>
        /// 
        /// </summary>
        public ProcessorUsage()
        {
            this.counter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetCurrentValue()
        {
            if ((DateTime.UtcNow - lastSampleTime).TotalMilliseconds > sampleFrequencyMillis)
            {
                lock (syncLock)
                {
                    if ((DateTime.UtcNow - lastSampleTime).TotalMilliseconds > sampleFrequencyMillis)
                    {
                        lastSample = counter.NextValue();
                        lastSampleTime = DateTime.UtcNow;
                    }
                }
            }
    
            return lastSample;
        }
    }
