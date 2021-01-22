    /// <summary>
    /// type to set signals or check for them using a central file 
    /// </summary>
    public class FileSignal
    {
        /// <summary>
        /// path to the central file for signal control
        /// </summary>
        public string FilePath { get; private set; }
        /// <summary>
        /// numbers of retries when not able to retrieve (exclusive) file access
        /// </summary>
        public int MaxCollisions { get; private set; }
        /// <summary>
        /// timespan to wait until next try
        /// </summary>
        public TimeSpan SleepOnCollisionInterval { get; private set; }
        /// <summary>
        /// Timestamp of the last signal
        /// </summary>
        public DateTime LastSignal { get; private set; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="filePath">path to the central file for signal control</param>
        /// <param name="maxCollisions">numbers of retries when not able to retrieve (exclusive) file access</param>
        /// <param name="sleepOnCollisionInterval">timespan to wait until next try </param>
        public FileSignal(string filePath, int maxCollisions, TimeSpan sleepOnCollisionInterval)
        {
            FilePath = filePath;
            MaxCollisions = maxCollisions;
            SleepOnCollisionInterval = sleepOnCollisionInterval;
            LastSignal = GetSignalTimeStamp();
        }
        /// <summary>
        /// constructor using a default value of 50 ms for sleepOnCollisionInterval
        /// </summary>
        /// <param name="filePath">path to the central file for signal control</param>
        /// <param name="maxCollisions">numbers of retries when not able to retrieve (exclusive) file access</param>        
        public FileSignal(string filePath, int maxCollisions): this (filePath, maxCollisions, TimeSpan.FromMilliseconds(50))
        {
        }
        /// <summary>
        /// constructor using a default value of 50 ms for sleepOnCollisionInterval and a default value of 10 for maxCollisions
        /// </summary>
        /// <param name="filePath">path to the central file for signal control</param>        
        public FileSignal(string filePath) : this(filePath, 10)
        {
        }
        private Stream GetFileStream(FileAccess fileAccess)
        {
            var i = 0;
            while (true)
            {
                try
                {
                    return new FileStream(FilePath, FileMode.Create, fileAccess, FileShare.None);
                }
                catch (Exception e)
                {
                    i++;
                    if (i >= MaxCollisions)
                    {
                        throw e;
                    }
                    Thread.Sleep(SleepOnCollisionInterval);
                };
            };
        }
        private DateTime GetSignalTimeStamp()
        {
            if (!File.Exists(FilePath))
            {
                return DateTime.MinValue;
            }
            using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                if(stream.Length == 0)
                {
                    return DateTime.MinValue;
                }
                using (var reader = new BinaryReader(stream))
                {
                    return DateTime.FromBinary(reader.ReadInt64());
                };                
            }
        }
        /// <summary>
        /// overwrites the existing central file and writes the current time into it.
        /// </summary>
        public void Signal()
        {
            LastSignal = DateTime.Now;
            using (var stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(LastSignal.ToBinary());
                }
            }
        }
        /// <summary>
        /// returns true if the file signal has changed, otherwise false.
        /// </summary>        
        public bool CheckIfSignalled()
        {
            var signal = GetSignalTimeStamp();
            var signalTimestampChanged = LastSignal != signal;
            LastSignal = signal;
            return signalTimestampChanged;
        }
    }
