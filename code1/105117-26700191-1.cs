    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace MyCSharpLibrary
    {
        public class Volume
        {
            [DllImport("winmm.dll")]
            public static extern int waveOutGetVolume(IntPtr h, out uint dwVolume);
    
            [DllImport("winmm.dll")]
            public static extern int waveOutSetVolume(IntPtr h, uint dwVolume);
    
            private static uint _savedVolumeLevel;
            private static Boolean VolumeLevelSaved = false;
    
            // ----------------------------------------------------------------------------
            public static void On()
            {
                if (VolumeLevelSaved)
                {
                    waveOutSetVolume(IntPtr.Zero, _savedVolumeLevel);
                }
            }
    
            // ----------------------------------------------------------------------------
            public static void Off()
            {
                waveOutGetVolume(IntPtr.Zero, out _savedVolumeLevel);
                VolumeLevelSaved = true;
               
                waveOutSetVolume(IntPtr.Zero, 0);
            }
        }
    }
