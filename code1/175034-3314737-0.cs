    struct PROCESSOR_POWER_POLICY_INFO 
    { 
        public uint TimeCheck;                  // ULONG 
        public uint DemoteLimit;                // ULONG 
        public uint PromoteLimit;               // ULONG 
        public byte DemotePercent; 
        public byte PromotePercent; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] 
        public byte[] Spare; 
        //public uint AllowDemotion; 
        //public uint AllowPromotion; 
        //public uint Reserved; 
        public uint AllowBits;
    } 
    struct PROCESSOR_POWER_POLICY 
    { 
        public uint Revision;                   // DWORD 
        public byte DynamicThrottle; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] 
        public byte[] Spare; 
        //public uint DisableCStates;             // DWORD 
        public uint Reserved;                   // DWORD 
        public uint PolicyCount;                // DWORD 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] 
        public PROCESSOR_POWER_POLICY_INFO[] Policy; 
    } 
