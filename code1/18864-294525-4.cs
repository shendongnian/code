    const int MAXPNAMELEN            = 32;
    const int MIXER_SHORT_NAME_CHARS = 16;
    const int MIXER_LONG_NAME_CHARS  = 64;
    [Flags] enum MIXERLINE_LINEF : uint{
        ACTIVE       = 0x00000001,
        DISCONNECTED = 0x00008000,
        SOURCE       = 0x80000000
    }
    [Flags] enum MIXER           : uint{
        GETLINEINFOF_DESTINATION     = 0x00000000,
        GETLINEINFOF_SOURCE          = 0x00000001,
        GETLINEINFOF_LINEID          = 0x00000002,
        GETLINEINFOF_COMPONENTTYPE   = 0x00000003,
        GETLINEINFOF_TARGETTYPE      = 0x00000004,
        GETLINEINFOF_QUERYMASK       = 0x0000000F,
        GETLINECONTROLSF_ALL         = 0x00000000,
        GETLINECONTROLSF_ONEBYID     = 0x00000001,
        GETLINECONTROLSF_ONEBYTYPE   = 0x00000002,
        GETLINECONTROLSF_QUERYMASK   = 0x0000000F,
        GETCONTROLDETAILSF_VALUE     = 0x00000000,
        GETCONTROLDETAILSF_LISTTEXT  = 0x00000001,
        GETCONTROLDETAILSF_QUERYMASK = 0x0000000F,
        OBJECTF_MIXER                = 0x00000000,
        OBJECTF_WAVEOUT              = 0x10000000,
        OBJECTF_WAVEIN               = 0x20000000,
        OBJECTF_MIDIOUT              = 0x30000000,
        OBJECTF_MIDIIN               = 0x40000000,
        OBJECTF_AUX                  = 0x50000000,
        OBJECTF_HANDLE               = 0x80000000,
        OBJECTF_HMIXER               = OBJECTF_HANDLE | OBJECTF_MIXER,
        OBJECTF_HWAVEOUT             = OBJECTF_HANDLE | OBJECTF_WAVEOUT,
        OBJECTF_HWAVEIN              = OBJECTF_HANDLE | OBJECTF_WAVEIN,
        OBJECTF_HMIDIOUT             = OBJECTF_HANDLE | OBJECTF_MIDIOUT,
        OBJECTF_HMIDIIN              = OBJECTF_HANDLE | OBJECTF_MIDIIN
    }
    [Flags] enum MIXERCONTROL_CT : uint{
        CLASS_MASK        = 0xF0000000,
        CLASS_CUSTOM      = 0x00000000,
        CLASS_METER       = 0x10000000,
        CLASS_SWITCH      = 0x20000000,
        CLASS_NUMBER      = 0x30000000,
        CLASS_SLIDER      = 0x40000000,
        CLASS_FADER       = 0x50000000,
        CLASS_TIME        = 0x60000000,
        CLASS_LIST        = 0x70000000,
        SUBCLASS_MASK     = 0x0F000000,
        SC_SWITCH_BOOLEAN = 0x00000000,
        SC_SWITCH_BUTTON  = 0x01000000,
        SC_METER_POLLED   = 0x00000000,
        SC_TIME_MICROSECS = 0x00000000,
        SC_TIME_MILLISECS = 0x01000000,
        SC_LIST_SINGLE    = 0x00000000,
        SC_LIST_MULTIPLE  = 0x01000000,
        UNITS_MASK        = 0x00FF0000,
        UNITS_CUSTOM      = 0x00000000,
        UNITS_BOOLEAN     = 0x00010000,
        UNITS_SIGNED      = 0x00020000,
        UNITS_UNSIGNED    = 0x00030000,
        UNITS_DECIBELS    = 0x00040000, /* in 10ths */
        UNITS_PERCENT     = 0x00050000, /* in 10ths */
    }
    [Flags] enum MIXERCONTROL_CONTROLTYPE : uint{
        CUSTOM         = MIXERCONTROL_CT.CLASS_CUSTOM | MIXERCONTROL_CT.UNITS_CUSTOM,
        BOOLEANMETER   = MIXERCONTROL_CT.CLASS_METER | MIXERCONTROL_CT.SC_METER_POLLED | MIXERCONTROL_CT.UNITS_BOOLEAN,
        SIGNEDMETER    = MIXERCONTROL_CT.CLASS_METER | MIXERCONTROL_CT.SC_METER_POLLED | MIXERCONTROL_CT.UNITS_SIGNED,
        PEAKMETER      = SIGNEDMETER + 1,
        UNSIGNEDMETER  = MIXERCONTROL_CT.CLASS_METER | MIXERCONTROL_CT.SC_METER_POLLED | MIXERCONTROL_CT.UNITS_UNSIGNED,
        BOOLEAN        = MIXERCONTROL_CT.CLASS_SWITCH | MIXERCONTROL_CT.SC_SWITCH_BOOLEAN | MIXERCONTROL_CT.UNITS_BOOLEAN,
        ONOFF          = BOOLEAN + 1,
        MUTE           = BOOLEAN + 2,
        MONO           = BOOLEAN + 3,
        LOUDNESS       = BOOLEAN + 4,
        STEREOENH      = BOOLEAN + 5,
        BASS_BOOST     = BOOLEAN + 0x00002277,
        BUTTON         = MIXERCONTROL_CT.CLASS_SWITCH | MIXERCONTROL_CT.SC_SWITCH_BUTTON | MIXERCONTROL_CT.UNITS_BOOLEAN,
        DECIBELS       = MIXERCONTROL_CT.CLASS_NUMBER | MIXERCONTROL_CT.UNITS_DECIBELS,
        SIGNED         = MIXERCONTROL_CT.CLASS_NUMBER | MIXERCONTROL_CT.UNITS_SIGNED,
        UNSIGNED       = MIXERCONTROL_CT.CLASS_NUMBER | MIXERCONTROL_CT.UNITS_UNSIGNED,
        PERCENT        = MIXERCONTROL_CT.CLASS_NUMBER | MIXERCONTROL_CT.UNITS_PERCENT,
        SLIDER         = MIXERCONTROL_CT.CLASS_SLIDER | MIXERCONTROL_CT.UNITS_SIGNED,
        PAN            = SLIDER + 1,
        QSOUNDPAN      = SLIDER + 2,
        FADER          = MIXERCONTROL_CT.CLASS_FADER | MIXERCONTROL_CT.UNITS_UNSIGNED,
        VOLUME         = FADER + 1,
        BASS           = FADER + 2,
        TREBLE         = FADER + 3,
        EQUALIZER      = FADER + 4,
        SINGLESELECT   = MIXERCONTROL_CT.CLASS_LIST | MIXERCONTROL_CT.SC_LIST_SINGLE | MIXERCONTROL_CT.UNITS_BOOLEAN,
        MUX            = SINGLESELECT + 1,
        MULTIPLESELECT = MIXERCONTROL_CT.CLASS_LIST | MIXERCONTROL_CT.SC_LIST_MULTIPLE | MIXERCONTROL_CT.UNITS_BOOLEAN,
        MIXER          = MULTIPLESELECT + 1,
        MICROTIME      = MIXERCONTROL_CT.CLASS_TIME | MIXERCONTROL_CT.SC_TIME_MICROSECS | MIXERCONTROL_CT.UNITS_UNSIGNED,
        MILLITIME      = MIXERCONTROL_CT.CLASS_TIME | MIXERCONTROL_CT.SC_TIME_MILLISECS | MIXERCONTROL_CT.UNITS_UNSIGNED
    }
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    struct MIXERLINE{
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct TargetInfo{
            public uint   dwType;
            public uint   dwDeviceID;
            public ushort wMid;
            public ushort wPid;
            public uint   vDriverVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAXPNAMELEN)]
            public string szPname;
        }
        public uint            cbStruct;
        public uint            dwDestination;
        public uint            dwSource;
        public uint            dwLineID;
        public MIXERLINE_LINEF fdwLine;
        public uint            dwUser;
        public uint            dwComponentType;
        public uint            cChannels;
        public uint            cConnection;
        public uint            cControls;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MIXER_SHORT_NAME_CHARS)]
        public string          szShortName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MIXER_LONG_NAME_CHARS)]
        public string          szName;
        public TargetInfo      Target;
    }
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    struct MIXERCONTROL{
        [StructLayout(LayoutKind.Explicit)]
        public struct BoundsInfo{
            [FieldOffset(0)]
            public int    lMinimum;
            [FieldOffset(4)]
            public int    lMaximum;
            [FieldOffset(0)]
            public uint   dwMinimum;
            [FieldOffset(4)]
            public uint   dwMaximum;
            [FieldOffset(8), MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
            public uint[] dwReserved;
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct MetricsInfo{
            [FieldOffset(0)]
            public uint   cSteps;
            [FieldOffset(0)]
            public uint   cbCustomData;
            [FieldOffset(4), MarshalAs(UnmanagedType.ByValArray, SizeConst=5)]
            public uint[] dwReserved;
        }
        
        public uint                     cbStruct;
        public uint                     dwControlID;
        public MIXERCONTROL_CONTROLTYPE dwControlType;
        public uint                     fdwControl;
        public uint                     cMultipleItems;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MIXER_SHORT_NAME_CHARS)]
        public string                   szShortName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MIXER_LONG_NAME_CHARS)]
        public string                   szName;
        public BoundsInfo               Bounds;
        public MetricsInfo              Metrics;
    }
    [StructLayout(LayoutKind.Explicit)]
    struct MIXERLINECONTROLS{
        [FieldOffset(0)]
        public uint   cbStruct;
        [FieldOffset(4)]
        public uint   dwLineID;
        [FieldOffset(8)]
        public uint   dwControlID;
        [FieldOffset(8)] // not a typo!  overlaps previous field
        public uint   dwControlType;
        [FieldOffset(12)]
        public uint   cControls;
        [FieldOffset(16)]
        public uint   cbmxctrl;
        [FieldOffset(20)]
        public IntPtr pamxctrl;
    }
    [StructLayout(LayoutKind.Explicit)]
    struct MIXERCONTROLDETAILS{
        [FieldOffset(0)]
        public uint   cbStruct;
        [FieldOffset(4)]
        public uint   dwControlID;
        [FieldOffset(8)]
        public uint   cChannels;
        [FieldOffset(12)]
        public IntPtr hwndOwner;
        [FieldOffset(12)] // not a typo!
        public uint   cMultipleItems;
        [FieldOffset(16)]
        public uint   cbDetails;
        [FieldOffset(20)]
        public IntPtr paDetails;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct VOLUME{
        public int left;
        public int right;
    }
    struct MixerInfo{
        public uint volumeCtl;
        public uint muteCtl;
        public int  minVolume;
        public int  maxVolume;
    }
    [DllImport("WinMM.dll", CharSet=CharSet.Auto)]
    static extern uint mixerGetLineInfo      (IntPtr hmxobj, ref MIXERLINE pmxl, MIXER flags);
    [DllImport("WinMM.dll", CharSet=CharSet.Auto)]
    static extern uint mixerGetLineControls  (IntPtr hmxobj, ref MIXERLINECONTROLS pmxlc, MIXER flags);
    [DllImport("WinMM.dll", CharSet=CharSet.Auto)]
    static extern uint mixerGetControlDetails(IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, MIXER flags);
    [DllImport("WinMM.dll", CharSet=CharSet.Auto)]
    static extern uint mixerSetControlDetails(IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, MIXER flags);
    static MixerInfo GetMixerControls(){
        MIXERLINE         mxl = new MIXERLINE();
        MIXERLINECONTROLS mlc = new MIXERLINECONTROLS();
        mxl.cbStruct = (uint)Marshal.SizeOf(typeof(MIXERLINE));
        mlc.cbStruct = (uint)Marshal.SizeOf(typeof(MIXERLINECONTROLS));
        mixerGetLineInfo(IntPtr.Zero, ref mxl, MIXER.OBJECTF_MIXER | MIXER.GETLINEINFOF_DESTINATION);
        mlc.dwLineID  = mxl.dwLineID;
        mlc.cControls = mxl.cControls;
        mlc.cbmxctrl  = (uint)Marshal.SizeOf(typeof(MIXERCONTROL));
        mlc.pamxctrl  = Marshal.AllocHGlobal((int)(mlc.cbmxctrl * mlc.cControls));
        mixerGetLineControls(IntPtr.Zero, ref mlc, MIXER.OBJECTF_MIXER | MIXER.GETLINECONTROLSF_ALL);
        MixerInfo rtn = new MixerInfo();
        for(int i = 0; i < mlc.cControls; i++){
            MIXERCONTROL mxc = (MIXERCONTROL)Marshal.PtrToStructure((IntPtr)((int)mlc.pamxctrl + (int)mlc.cbmxctrl * i), typeof(MIXERCONTROL));
            switch(mxc.dwControlType){
            case MIXERCONTROL_CONTROLTYPE.VOLUME:
                rtn.volumeCtl = mxc.dwControlID;
                rtn.minVolume = mxc.Bounds.lMinimum;
                rtn.maxVolume = mxc.Bounds.lMaximum;
                break;
            case MIXERCONTROL_CONTROLTYPE.MUTE:
                rtn.muteCtl = mxc.dwControlID;
                break;
            }
        }
        Marshal.FreeHGlobal(mlc.pamxctrl);
        return rtn;
    }
    static VOLUME GetVolume(MixerInfo mi){
        MIXERCONTROLDETAILS mcd = new MIXERCONTROLDETAILS();
        mcd.cbStruct       = (uint)Marshal.SizeOf(typeof(MIXERCONTROLDETAILS));
        mcd.dwControlID    = mi.volumeCtl;
        mcd.cMultipleItems = 0;
        mcd.cChannels      = 2;
        mcd.cbDetails      = (uint)Marshal.SizeOf(typeof(int));
        mcd.paDetails      = Marshal.AllocHGlobal((int)mcd.cbDetails);
        mixerGetControlDetails(IntPtr.Zero, ref mcd, MIXER.GETCONTROLDETAILSF_VALUE | MIXER.OBJECTF_MIXER);
        VOLUME rtn = (VOLUME)Marshal.PtrToStructure(mcd.paDetails, typeof(VOLUME));
 
        Marshal.FreeHGlobal(mcd.paDetails);
        return rtn;
    }
    static bool IsMuted(MixerInfo mi){
        MIXERCONTROLDETAILS mcd = new MIXERCONTROLDETAILS();
        mcd.cbStruct       = (uint)Marshal.SizeOf(typeof(MIXERCONTROLDETAILS));
        mcd.dwControlID    = mi.muteCtl;
        mcd.cMultipleItems = 0;
        mcd.cChannels      = 1;
        mcd.cbDetails      = 4;
        mcd.paDetails      = Marshal.AllocHGlobal((int)mcd.cbDetails);
        mixerGetControlDetails(IntPtr.Zero, ref mcd, MIXER.GETCONTROLDETAILSF_VALUE | MIXER.OBJECTF_MIXER);
        int rtn = Marshal.ReadInt32(mcd.paDetails);
 
        Marshal.FreeHGlobal(mcd.paDetails);
        return rtn != 0;
    }
    static void AdjustVolume(MixerInfo mi, int delta){
        VOLUME volume = GetVolume(mi);
        if(delta > 0){
            volume.left  = Math.Min(mi.maxVolume, volume.left  + delta);
            volume.right = Math.Min(mi.maxVolume, volume.right + delta);
        }else{
            volume.left  = Math.Max(mi.minVolume, volume.left  + delta);
            volume.right = Math.Max(mi.minVolume, volume.right + delta);
        }
        SetVolume(mi, volume);
    }
    static void SetVolume(MixerInfo mi, VOLUME volume){
        MIXERCONTROLDETAILS mcd = new MIXERCONTROLDETAILS();
        mcd.cbStruct       = (uint)Marshal.SizeOf(typeof(MIXERCONTROLDETAILS));
        mcd.dwControlID    = mi.volumeCtl;
        mcd.cMultipleItems = 0;
        mcd.cChannels      = 2;
        mcd.cbDetails      = (uint)Marshal.SizeOf(typeof(int));
        mcd.paDetails      = Marshal.AllocHGlobal((int)mcd.cbDetails);
        Marshal.StructureToPtr(volume, mcd.paDetails, false);
        mixerSetControlDetails(IntPtr.Zero, ref mcd, MIXER.GETCONTROLDETAILSF_VALUE | MIXER.OBJECTF_MIXER);
        Marshal.FreeHGlobal(mcd.paDetails);
    }
    static void SetMute(MixerInfo mi, bool mute){
        MIXERCONTROLDETAILS mcd = new MIXERCONTROLDETAILS();
        mcd.cbStruct       = (uint)Marshal.SizeOf(typeof(MIXERCONTROLDETAILS));
        mcd.dwControlID    = mi.muteCtl;
        mcd.cMultipleItems = 0;
        mcd.cChannels      = 1;
        mcd.cbDetails      = 4;
        mcd.paDetails      = Marshal.AllocHGlobal((int)mcd.cbDetails);
        Marshal.WriteInt32(mcd.paDetails, mute ? 1 : 0);
        mixerSetControlDetails(IntPtr.Zero, ref mcd, MIXER.GETCONTROLDETAILSF_VALUE | MIXER.OBJECTF_MIXER);
        Marshal.FreeHGlobal(mcd.paDetails);
    }
