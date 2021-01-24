        private int IsMuted() {
            IAudioEndpointVolume masterVol = null;
            try {
                masterVol = GetMasterVolumeObject();
                if( masterVol == null )
                    return -1; //error
                bool isMuted;
                masterVol.GetMute( out isMuted );
                return Convert.ToInt32( isMuted );
            }
            finally {
                if( masterVol != null )
                    Marshal.ReleaseComObject( masterVol );
            }
        }
        private IAudioEndpointVolume GetMasterVolumeObject() {
            IMMDeviceEnumerator deviceEnumerator = null;
            IMMDevice speakers = null;
            try {
                deviceEnumerator = (IMMDeviceEnumerator)( new MMDeviceEnumerator() );
                deviceEnumerator.GetDefaultAudioEndpoint( EDataFlow.eRender, ERole.eMultimedia, out speakers );
                Guid IID_IAudioEndpointVolume = typeof( IAudioEndpointVolume ).GUID;
                object o;
                speakers.Activate( ref IID_IAudioEndpointVolume, 0, IntPtr.Zero, out o );
                IAudioEndpointVolume masterVol = (IAudioEndpointVolume)o;
                return masterVol;
            }
            finally {
                if( speakers != null ) Marshal.ReleaseComObject( speakers );
                if( deviceEnumerator != null ) Marshal.ReleaseComObject( deviceEnumerator );
            }
        }
