    struct sTestStruct
    {
        public int numberOne;
        public int numberTwo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=128)]
        public int[] numbers; // This is ALWAYS 128 ints long. 
        public bool trueFalse;
    }
