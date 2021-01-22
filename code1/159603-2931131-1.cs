    using System;
    using System.Runtime.InteropServices;
    
    namespace MouseSpeedSwitcher
    {
        class Program
        {
            public const UInt32 SPI_SETMOUSESPEED = 0x0071;
    
            [DllImport("User32.dll")]
            static extern Boolean SystemParametersInfo(
                UInt32 uiAction, 
                UInt32 uiParam, 
                UInt32 pvParam,
                UInt32 fWinIni);
    
            static void Main(string[] args)
            {
                SystemParametersInfo(
                    SPI_SETMOUSESPEED, 
                    0, 
                    uint.Parse(args[0]), 
                    0);
            }
        }
    }
