    public class APD : IDevice
     {
        // Some members and properties go here, removed for clarity.
        public event EventHandler ErrorOccurred;
        public event EventHandler NewCountsAvailable;
        public UInt32[] BufferedCounts
        {
            // Get for the _ui32Values returned by the EndReadMultiSampleUInt32() 
            // after they were appended to a list. BufferdCounts therefore supplies 
            // all values read during the experiment.
        } 
        public bool IsDone
        {
            // This gets set when a preset number of counts is read by the hardware or when
            // Stop() is called.
        }
        // Constructor
        public APD( some parameters )
        {
           // Removed for clarity.
        }
        private void APDReadCallback(IAsyncResult __iaresResult)
        {
            try
            {
                if (this.m_daqtskRunningTask == __iaresResult.AsyncState)
                {
                    // Get back the values read.
                    UInt32[] _ui32Values = this.m_rdrCountReader.EndReadMultiSampleUInt32(__iaresResult);
                    // Do some processing here!
                    if (NewCountsAvailable != null)
                    {
                        NewCountsAvailable(this, new EventArgs());
                    }
                    // Read again only if we did not yet read all pixels.
                    if (this.m_dTotalCountsRead != this.m_iPixelsToRead)
                    {
                        this.m_rdrCountReader.BeginReadMultiSampleUInt32(-1, this.m_acllbckCallback, this.m_daqtskAPDCount);
                    }
                    else
                    {
                        // Removed for clarity.
                    }
                }
            }
            catch (DaqException exception)
            {
                // Removed for clarity.
            }
        }
        private void SetupAPDCountAndTiming(double __dBinTimeMilisec, int __iSteps)
        {
            // Do some things to prepare hardware.
        }
        public void StartAPDAcquisition(double __dBinTimeMilisec, int __iSteps)
        {
            this.m_bIsDone = false;
            // Prepare all necessary tasks.
            this.SetupAPDCountAndTiming(__dBinTimeMilisec, __iSteps);
            // Removed for clarity.
            // Begin reading asynchronously on the task. We always read all available counts.
            this.m_rdrCountReader.BeginReadMultiSampleUInt32(-1, this.m_acllbckCallback, this.m_daqtskAPDCount); 
        }
        public void Stop()
        {
           // Removed for clarity. 
        }
    }
