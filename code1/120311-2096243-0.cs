    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace WmpTestPlugin
    {
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("695386EC-AA3C-4618-A5E1-DD9A8B987632")]
        public interface IWmpEffects2 : IWmpEffects
        {
            [PreserveSig]
            new int Render(ref TimedLevel pLevels, IntPtr Hdc, ref RECT pRC);
            [PreserveSig]
            new int MediaInfo(int lChannelCount, int lSampleRate, string bstrTitle);
            [PreserveSig]
            new int GetCapabilities(ref int pdwCapabilities);
            [PreserveSig]
            new int GetTitle(ref string bstrTitle);
            [PreserveSig]
            new int GetPresetTitle(int nPreset, ref string bstrPresetTitle);
            [PreserveSig]
            new int GetPresetCount(ref int count);
            [PreserveSig]
            new int SetCurrentPreset(int currentpreset);
            [PreserveSig]
            new int GetCurrentPreset(ref int currentpreset);
            [PreserveSig]
            new int DisplayPropertyPage(IntPtr hwndOwner);
            [PreserveSig]
            new int GoFullScreen(bool fFullscreen);
            [PreserveSig]
            new int RenderFullScreen(ref TimedLevel pLevels);
    
            [PreserveSig]
            int SetCore(IntPtr pPlayer);
            [PreserveSig]
            int Create(IntPtr hwndParent);
            [PreserveSig]
            int Destroy();
            [PreserveSig]
            int NotifyNewMedia(IntPtr pMedia);
            [PreserveSig]
            int OnWindowMessage(int Msg, int WParam, int LParam, ref int plResultParam);
            [PreserveSig]
            int RenderWindowed(ref TimedLevel pData, bool fRequiredRender);
        }
    
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("D3984C13-C3CB-48e2-8BE5-5168340B4F35")]
        public interface IWmpEffects
        {
            [PreserveSig]
            int Render(ref TimedLevel pLevels, IntPtr Hdc, ref RECT pRC);
            [PreserveSig]
            int MediaInfo(int lChannelCount, int lSampleRate, string bstrTitle);
            [PreserveSig]
            int GetCapabilities(ref int pdwCapabilities);
            [PreserveSig]
            int GetTitle(ref string bstrTitle);
            [PreserveSig]
            int GetPresetTitle(int nPreset, ref string bstrPresetTitle);
            [PreserveSig]
            int GetPresetCount(ref int count);
            [PreserveSig]
            int SetCurrentPreset(int currentpreset);
            [PreserveSig]
            int GetCurrentPreset(ref int currentpreset);
            [PreserveSig]
            int DisplayPropertyPage(IntPtr hwndOwner);
            [PreserveSig]
            int GoFullScreen(bool fFullscreen);
            [PreserveSig]
            int RenderFullScreen(ref TimedLevel pLevels);
        }
    
    
        //[ComVisible(true)]
        [StructLayout(LayoutKind.Sequential)]
        public struct Data
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x400)]
            public byte[] Data0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x400)]
            public byte[] Data1;
        }
    
        //[ComVisible(true)]
        public enum PlayerState
        {
            Stop_State,
            Pause_State,
            Play_State
        }
    
        //[ComVisible(true)]
        [StructLayout(LayoutKind.Sequential)]
        public struct TimedLevel
        {
            public Data Frequency;
            public Data Waveform;
            public PlayerState State;
            public long TimeStamp;
        }
    
        //[ComVisible(true)]
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public int Width { get { return this.Right - this.Left; } }
            public int Height { get { return this.Bottom - this.Top; } }
        }
    }
