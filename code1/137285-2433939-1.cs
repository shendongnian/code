    class HardwareSettings
    {
        public TiltSettings TiltSettings { get; set; }
        public CameraSetting CameraSetting { get; set; }
    }
        struct CameraSetting
        {
            public int Width
            { get; set; }
    
            public int Height
            { get; set; }
            public int Depth
            { get; set; }
        }
    
        struct TiltSettings
        {
            int Theta { get; set; }
            int Rho { get; set; }
        }
