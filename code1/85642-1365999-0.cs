    namespace Messages
    {
        public static class Generic
        { 
            // these messages are 3-figure numbers
            public const Int32 Unknown = 0;
            public const Int32 Initialize = 101;
            ...
            public const Int32 Destroy = 110;
        }
    
        public static class Graphics
        {
            // these messages are 4-figure numbers
            public const Int32 Unknown = 0;
            public const Int32 AddGraphic = 1001; // <-- ?
            // and so on...
        }
    
    }
