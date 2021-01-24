        enum MemoryResourceNotificationType : int
        {
            LowMemoryResourceNotification = 0,
            HighMemoryResourceNotification = 1,
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateMemoryResourceNotification(MemoryResourceNotificationType notificationType);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool QueryMemoryResourceNotification(IntPtr resourceNotificationHandle, out int resourceState);
        private static IntPtr MemoryResourceNotificationHandle;
        public static void TryReclaim()
        {
            MemoryResourceNotificationHandle = CreateMemoryResourceNotification(MemoryResourceNotificationType.LowMemoryResourceNotification);
            int sleepIntervalInMs = ReclaimIntervalInSeconds * 1000;
            while (true)
            {
                Thread.Sleep(10_000);
                bool isSuccecced = QueryMemoryResourceNotification(MemoryResourceNotificationHandle, out int memoryStatus);
                if (isSuccecced)
                {
                    if (memoryStatus >= 1)
                    {
                       DoReclaim();
                    }
                    
                }
                
            }           
            
        }
