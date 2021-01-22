    /// <summary>
            /// Populates a memory status struct with the machines current memory status.
            /// </summary>
            /// <param name="stat">The status struct to be populated.</param>
            [DllImport("kernel32.dll")]
            public static extern void GlobalMemoryStatus(out MemoryStatus stat);
    
    
            /// <summary>
            /// The memory status struct is populated by the GlobalMemoryStatus external dll call to Kernal32.dll.
            /// </summary>
            public struct MemoryStatus
            {
                public uint Length;
                public uint MemoryLoad;
                public uint TotalPhysical;
                public uint AvailablePhysical;
                public uint TotalPageFile;
                public uint AvailablePageFile;
                public uint TotalVirtual;
                public uint AvailableVirtual;
            } 
    
    // copy the guts of this method and add it to your own method.
    public void InspectMemoryStatus()
    {
    
    MemoryStatus status = new MemoryStatus();
                GlobalMemoryStatus(out status);
    
        Debug.WriteLine(status.TotalVirtual);
    }
