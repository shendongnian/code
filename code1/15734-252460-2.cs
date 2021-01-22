    using System;
    using System.Windows.Forms;
    using Microsoft.Win32.SafeHandles;
    using System.Diagnostics;
    using MWin32Api;
    
    namespace WFConsole
    {
        static class Program
        {
            static private SafeFileHandle ConsoleHandle;
    
            /// <summary>
            /// Initialize the Win32 console for this process.
            /// </summary>
            static private void InitWin32Console()
            {
                if ( !K32.AllocConsole() ) {
                    MessageBox.Show( "Cannot allocate console",
                                     "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error );
                    return;
                }
    
                IntPtr handle = K32.CreateFile(
                                     "CONOUT$",                                    // name
                                     K32.GENERIC_WRITE | K32.GENERIC_READ,         // desired access
                                     K32.FILE_SHARE_WRITE | K32.FILE_SHARE_READ,   // share access
                                     null,                                         // no security attributes
                                     K32.OPEN_EXISTING,                            // device already exists
                                     0,                                            // no flags or attributes
                                     IntPtr.Zero );                                // no template file.
    
                ConsoleHandle = new SafeFileHandle( handle, true );
    
                if ( ConsoleHandle.IsInvalid ) {
                    MessageBox.Show( "Cannot create diagnostic console",
                                     "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error );
                    return;
                }
    
                //
                // Set the console screen buffer and window to a reasonable size
                //  1) set the screen buffer sizse
                //  2) Get the maximum window size (in terms of characters) 
                //  3) set the window to be this size
                //
                const UInt16 conWidth     = 256;
                const UInt16 conHeight    = 5000;
    
                K32.Coord dwSize = new K32.Coord( conWidth, conHeight );
                if ( !K32.SetConsoleScreenBufferSize( ConsoleHandle.DangerousGetHandle(), dwSize ) ) {
                    MessageBox.Show( "Can't get console screen buffer information.",
                                     "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error );
                    return;
                }
    
                K32.Console_Screen_Buffer_Info SBInfo = new K32.Console_Screen_Buffer_Info();
                if ( !K32.GetConsoleScreenBufferInfo( ConsoleHandle.DangerousGetHandle(), out SBInfo ) ) {
                    MessageBox.Show( "Can't get console screen buffer information.",
                                     "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);
                    return;
                }
    
                K32.Small_Rect sr; ;
                sr.Left = 0;
                sr.Top = 0;
                sr.Right = 132 - 1;
                sr.Bottom = 51 - 1;
    
                if ( !K32.SetConsoleWindowInfo( ConsoleHandle.DangerousGetHandle(), true, ref sr ) ) {
                    MessageBox.Show( "Can't set console screen buffer information.",
                                     "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error );
                    return;
                }
    
                IntPtr conHWND = K32.GetConsoleWindow();
    
                if ( conHWND == IntPtr.Zero ) {
                    MessageBox.Show( "Can't get console window handle.",
                                     "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error );
                    return;
                }
    
                if ( !U32.SetForegroundWindow( conHWND ) ) {
                    MessageBox.Show( "Can't set console window as foreground.",
                                     "Error",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error );
                    return;
                }
    
                K32.SetConsoleTitle( "Test - Console" );
    
                Trace.Listeners.Add( new ConsoleTraceListener() );
            }
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                InitWin32Console();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );
                Application.Run( new Main() );
            }
        }
    }
    
    
    using System;
    using System.Runtime.InteropServices;
    
    namespace MWin32Api
    {
        #region Kernel32 Functions
    
        //--------------------------------------------------------------------------
        /// <summary>
        /// Functions in Kernel32.dll
        /// </summary>
        public sealed class K32
        {
            #region Data Structures, Types and Constants
            //----------------------------------------------------------------------
            // Data Structures, Types and Constants
            // 
    
            [StructLayout( LayoutKind.Sequential )]
            public class SecurityAttributes
            {
                public UInt32  nLength;
                public UIntPtr lpSecurityDescriptor;
                public bool    bInheritHandle;
            }
    
            [StructLayout( LayoutKind.Sequential, Pack = 1, Size = 4 )]
            public struct Coord
            {
                public Coord( UInt16 tx, UInt16 ty )
                {
                    x = tx;
                    y = ty;
                }
                public UInt16 x;
                public UInt16 y;
            }
    
            [StructLayout( LayoutKind.Sequential, Pack = 1, Size = 8 )]
            public struct Small_Rect
            {
                public Int16 Left;
                public Int16 Top;
                public Int16 Right;
                public Int16 Bottom;
    
                public Small_Rect( short tLeft, short tTop, short tRight, short tBottom )
                {
                    Left = tLeft;
                    Top = tTop;
                    Right = tRight;
                    Bottom = tBottom;
                }
            }
    
            [StructLayout( LayoutKind.Sequential, Pack = 1, Size = 24 )]
            public struct Console_Screen_Buffer_Info
            {
                public Coord      dwSize;
                public Coord      dwCursorPosition;
                public UInt32     wAttributes;
                public Small_Rect srWindow;
                public Coord      dwMaximumWindowSize;
            }
    
    
            public const int ZERO_HANDLE_VALUE = 0;
            public const int INVALID_HANDLE_VALUE = -1;
    
            #endregion
            #region Console Functions
            //----------------------------------------------------------------------
            // Console Functions
            // 
            [DllImport( "kernel32.dll", SetLastError = true )]
            public static extern bool AllocConsole();
    
            [DllImport( "kernel32.dll", SetLastError = true )]
            public static extern bool SetConsoleScreenBufferSize(
                IntPtr hConsoleOutput,
                Coord dwSize );
    
            [DllImport( "kernel32.dll", SetLastError = true )]
            public static extern bool GetConsoleScreenBufferInfo(
                IntPtr hConsoleOutput,
                out Console_Screen_Buffer_Info lpConsoleScreenBufferInfo );
    
            [DllImport( "kernel32.dll", SetLastError = true )]
            public static extern bool SetConsoleWindowInfo(
                IntPtr hConsoleOutput,
                bool bAbsolute,
                ref Small_Rect lpConsoleWindow );
    
            [DllImport( "kernel32.dll", SetLastError = true )]
            public static extern IntPtr GetConsoleWindow();
    
            [DllImport( "kernel32.dll", SetLastError = true )]
            public static extern bool SetConsoleTitle(
                string Filename );
    
            #endregion
            #region Create File
            //----------------------------------------------------------------------
            // Create File
            // 
            public const UInt32 CREATE_NEW          = 1;
            public const UInt32 CREATE_ALWAYS       = 2;
            public const UInt32 OPEN_EXISTING       = 3;
            public const UInt32 OPEN_ALWAYS         = 4;
            public const UInt32 TRUNCATE_EXISTING   = 5;
            public const UInt32 FILE_SHARE_READ     = 1;
            public const UInt32 FILE_SHARE_WRITE    = 2;
            public const UInt32 GENERIC_WRITE       = 0x40000000;
            public const UInt32 GENERIC_READ        = 0x80000000;
    
            [DllImport( "kernel32.dll", SetLastError = true )]
            public static extern IntPtr CreateFile(
                string Filename,
                UInt32 DesiredAccess,
                UInt32 ShareMode,
                SecurityAttributes SecAttr,
                UInt32 CreationDisposition,
                UInt32 FlagsAndAttributes,
                IntPtr TemplateFile );
    
            #endregion
            #region Win32 Miscelaneous
            //----------------------------------------------------------------------
            // Miscelaneous
            // 
            [DllImport( "kernel32.dll" )]
            public static extern bool CloseHandle( UIntPtr handle );
    
            #endregion
    
            //----------------------------------------------------------------------
            private K32()
            {
            }
        }
        #endregion
    
        //--------------------------------------------------------------------------
        /// <summary>
        /// Functions in User32.dll
        /// </summary>
        #region User32 Functions
        public sealed class U32
        {
            [StructLayout( LayoutKind.Sequential )]
            public struct Rect
            {
                public Int32 Left;
                public Int32 Top;
                public Int32 Right;
                public Int32 Bottom;
    
                public Rect( short tLeft, short tTop, short tRight, short tBottom )
                {
                    Left = tLeft;
                    Top = tTop;
                    Right = tRight;
                    Bottom = tBottom;
                }
            }
    
            [DllImport( "user32.dll" )]
            public static extern bool GetWindowRect(
                IntPtr hWnd,
                [In][MarshalAs( UnmanagedType.LPStruct )]Rect lpRect );
    
            [DllImport( "user32.dll", SetLastError = true )]
            public static extern bool SetForegroundWindow(
                IntPtr hWnd );
    
            //----------------------------------------------------------------------
            private U32()
            {
            }
        } // U32 class
        #endregion
    } // MWin32Api namespace
