    public class sDrfGetFirmwareVersion
            {
                //apiStatus __declspec(dllexport) __stdcall DrfGetFirmwareVersion (HANDLE hCom, unsigned char *major,unsigned char *minor, unsigned char ReaderAddr = 0xff);
      
                [DllImport("DrfApiV10.dll", CallingConvention = CallingConvention.StdCall,CharSet=CharSet.Ansi,EntryPoint="DrfGetFirmwareVersion", ExactSpelling=false)]
                public static extern short DrfGetFirmwareVersion(IntPtr hCom, out byte major, out byte minor,byte ReaderAddr);
                public static short DrfGetFirmwareVersion(IntPtr hCom, out byte major,out byte minor)
                  {
                      return DrfGetFirmwareVersion(hCom, out major,out minor, 0xff);
                  }
            }
