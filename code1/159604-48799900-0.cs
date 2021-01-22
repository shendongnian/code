    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public const UInt32 SPI_GETMOUSESPEED = 0x0070;
    
    
            const UInt32 SPIF_UPDATEINIFILE = 0x01;
            const UInt32 SPIF_SENDWININICHANGE = 0x02;
    
            [DllImport("User32.dll")]
            static extern Boolean SystemParametersInfo(
                UInt32 uiAction,
                UInt32 uiParam,
                IntPtr pvParam,
                UInt32 fWinIni);
            
            static unsafe void Main(string[] args)
            {
               MouseOptions m = new MouseOptions();
    
                MouseOptions.GetDefaults();
                int speed;
                SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr(&speed), 0);
                Console.WriteLine(speed);
    
                MouseOptions.SetDefaults();
    
    
                SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr(&speed), 0);
                Console.WriteLine(speed);
                
    
                Console.ReadLine();
            }
    
    
    
            public class MouseOptions
            {
                [DllImport("user32.dll")]
                public static extern int SystemParametersInfo( int uAction, int uParam, IntPtr lpvParam, int fuWinIni );
    
                [DllImport("kernel32.dll")]
                public static extern int GetLastError();
         
                public const int SPI_GETMOUSESPEED = 112;
                public const int SPI_SETMOUSESPEED = 113;
    
    
                private static int intDefaulSpeed = 10;
                private static int intCurrentSpeed;
                private static int intNewSpeed;
    
                public static void GetDefaults()
                {
                    intCurrentSpeed = GetMouseSpeed();
                }
                public static void SetDefaults()
                {
                    if ( intCurrentSpeed == 20 )
                    {
                        SetMouseSpeed(intDefaulSpeed); 
                    }
                    else if ( intCurrentSpeed < 10 )
                    {
                        SetMouseSpeed(intDefaulSpeed);   
                    }
                }
    
                public static int GetMouseSpeed()
                {
                    int intSpeed = 0;
                    IntPtr ptr;
                    ptr = Marshal.AllocCoTaskMem(4);
                    SystemParametersInfo(SPI_GETMOUSESPEED, 0, ptr, 0);
                    intSpeed = Marshal.ReadInt32(ptr);
                    Marshal.FreeCoTaskMem(ptr);
    
                    return intSpeed;
                }
    
                public static void SetMouseSpeed( int intSpeed )
                {
                    IntPtr ptr = new IntPtr(intSpeed);
    
                    int b = SystemParametersInfo(SPI_SETMOUSESPEED, 0, ptr, 0);
    
                    if (b == 0)
                    {
                        Console.WriteLine("Not able to set speed");
                    }
                    else if ( b == 1 )
                    {
                        Console.WriteLine("Successfully done");
                    }
    
                }
                
            }
    
    
        }
    
    }
