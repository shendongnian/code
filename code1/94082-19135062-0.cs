            /// <summary>
            /// The DirectSoundEnumerate function enumerates the DirectSound Odrivers installed in the system.
            /// </summary>
            /// <param name="lpDSEnumCallback">callback function</param>
            /// <param name="lpContext">User context</param>
            [DllImport("dsound.dll", EntryPoint = "DirectSoundEnumerateA", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            static extern void DirectSoundEnumerate(DevicesEnumCallback lpDSEnumCallback, IntPtr lpContext);
