        public static long GetTimestamp() {
            if(IsHighResolution) {
                long timestamp = 0;    
                SafeNativeMethods.QueryPerformanceCounter(out timestamp);
                return timestamp;
            }
            else {
                return DateTime.UtcNow.Ticks;
            }   
        }
