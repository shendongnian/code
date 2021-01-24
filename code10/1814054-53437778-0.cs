    $HH = @"
    using System;
    public class HexHelper
    {
        public static string GetUTCFileTimeAsHexString()
        {
            string sHEX = "";
            long ftLong = DateTime.Now.ToFileTimeUtc();
            int ftHigh = (int)(ftLong >> 32);
            int ftLow = (int)ftLong;
            sHEX = ftHigh.ToString("X") + ":" + ftLow.ToString("X");
            return sHEX;
        }
    }
    "@;
    Add-Type -TypeDefinition $HH;
    $HexString = [HexHelper]::GetUTCFileTimeAsHexString();
    $HexString;
