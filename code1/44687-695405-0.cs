    public partial class NativeMethods {
        
        /// Return Type: BOOL->int
        ///pszSound: LPCWSTR->WCHAR*
        ///fuSound: UINT->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute("winmm.dll", EntryPoint="sndPlaySoundW")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
    public static extern  bool sndPlaySoundW([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string pszSound, uint fuSound) ;
        
        /// SND_APPLICATION -> 0x0080
        public const int SND_APPLICATION = 128;
        
        /// SND_ALIAS_START -> 0
        public const int SND_ALIAS_START = 0;
        
        /// SND_RESOURCE -> 0x00040004L
        public const int SND_RESOURCE = 262148;
        
        /// SND_FILENAME -> 0x00020000L
        public const int SND_FILENAME = 131072;
        
        /// SND_ALIAS_ID -> 0x00110000L
        public const int SND_ALIAS_ID = 1114112;
        
        /// SND_NOWAIT -> 0x00002000L
        public const int SND_NOWAIT = 8192;
        
        /// SND_NOSTOP -> 0x0010
        public const int SND_NOSTOP = 16;
        
        /// SND_MEMORY -> 0x0004
        public const int SND_MEMORY = 4;
        
        /// SND_PURGE -> 0x0040
        public const int SND_PURGE = 64;
        
        /// SND_ASYNC -> 0x0001
        public const int SND_ASYNC = 1;
        
        /// SND_ALIAS -> 0x00010000L
        public const int SND_ALIAS = 65536;
        
        /// SND_SYNC -> 0x0000
        public const int SND_SYNC = 0;
        
        /// SND_LOOP -> 0x0008
        public const int SND_LOOP = 8;
        
        /// SND_NODEFAULT -> 0x0002
        public const int SND_NODEFAULT = 2;
    }
    
   
