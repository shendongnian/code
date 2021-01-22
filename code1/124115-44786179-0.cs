    using System.Runtime.InteropServices;
    namespace Audio
    {
        internal static class NativeMethods
        {
            [DllImport("winmm.dll", EntryPoint = "PlaySound", SetLastError = true, CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
            public static extern bool PlaySound(
                string szSound,
                System.IntPtr hMod,
                PlaySoundFlags flags);
            [System.Flags]
            public enum PlaySoundFlags : int
            {
                SND_SYNC = 0x0000,/* play synchronously (default) */
                SND_ASYNC = 0x0001, /* play asynchronously */
                SND_NODEFAULT = 0x0002, /* silence (!default) if sound not found */
                SND_MEMORY = 0x0004, /* pszSound points to a memory file */
                SND_LOOP = 0x0008, /* loop the sound until next sndPlaySound */
                SND_NOSTOP = 0x0010, /* don't stop any currently playing sound */
                SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
                SND_ALIAS = 0x00010000,/* name is a registry alias */
                SND_ALIAS_ID = 0x00110000, /* alias is a pre d ID */
                SND_FILENAME = 0x00020000, /* name is file name */
                SND_RESOURCE = 0x00040004, /* name is resource name or atom */
                SND_PURGE = 0x0040,  /* purge non-static events for task */
                SND_APPLICATION = 0x0080, /* look for application specific association */
                SND_SENTRY = 0x00080000, /* Generate a SoundSentry event with this sound */
                SND_RING = 0x00100000, /* Treat this as a "ring" from a communications app - don't duck me */
                SND_SYSTEM = 0x00200000 /* Treat this as a system sound */
            }
        }
        public static class Play
        {
            public static void PlaySound(string path, string file = "")
            {            
                NativeMethods.PlaySound(path + file, new System.IntPtr(), NativeMethods.PlaySoundFlags.SND_ASYNC | NativeMethods.PlaySoundFlags.SND_SYSTEM);
            }
        }
    }
