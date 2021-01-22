    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.IO;
    using HWND = System.IntPtr;
    
    namespace RtfStream
    {
        public partial class Form1 : Form
        {
            private Win32API.EDITSTREAM _es; 
            private FileStream _fs = null;
            private MemoryStream _mStream;
            private IntPtr _globPtr = IntPtr.Zero;
            
            public Form1()
            {
                InitializeComponent();
                //
                this._mStream = new MemoryStream();
                //
                this._fs = new FileStream(@"C:\EditCb.rtf", FileMode.OpenOrCreate);
                //
                this._es = new Win32API.EDITSTREAM();
                this._es.dwCookie = this._fs.Handle;
                this._es.pfnCallback = new Win32API.EditStreamCallback(this.Form1_rtfCb);
                //
                this._globPtr = Marshal.AllocHGlobal(Marshal.SizeOf(this._es));
                if (this._globPtr.ToInt32() > 0) Marshal.StructureToPtr(this._es, this._globPtr, false);
            }
    
            public uint Form1_rtfCb(IntPtr dwCookie, IntPtr pbBuff, Int32 cb, IntPtr pcb)
            {
                uint result = 0;
                byte[] buf;
                if (cb > 0)
                {
                    buf = new byte[cb];
                    Marshal.Copy(pbBuff, buf, 0, cb);
                    this._mStream.Write(buf, 0, cb);
                    Marshal.WriteInt32(pcb, cb);
                }
                //
                System.Diagnostics.Debug.WriteLine("Form1_rtfCb");
                //
                return result;
            }
    
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                if (this._globPtr.ToInt32() > 0)
                {
                    IntPtr rv = Win32API.SendMessage(this.richTextBox1.Handle, Win32API.EM_STREAMOUT, new IntPtr(Win32API.SF_RTF), this._globPtr);
                    if (rv.ToInt32() != 0) System.Diagnostics.Debug.WriteLine("Fail");
                    else System.Diagnostics.Debug.WriteLine("OK");
    
                    byte[] mbStream = this._mStream.ToArray();
                    this._mStream.Close();
                    if (this._fs != null)
                    {
                        this._fs.Write(mbStream, 0, mbStream.Length);
                        this._fs.Close();
                    }
                    Marshal.FreeHGlobal(this._globPtr);
                    this._globPtr = IntPtr.Zero;
                    System.Diagnostics.Debug.WriteLine("Cleaned Up!");
                }
            }
        }
        public class Win32API
        {
            public const int EM_STREAMIN = 0x449;
            public const int EM_STREAMOUT = 0x44A;
            public const int SF_TEXT = 1;
            public const int SF_RTF	= 2;
            public const int SF_RTFNOOBJS = 3;
            public const int SF_TEXTIZED = 4;
            public const int SF_UNICODE = 16;
            public const int SF_USECODEPAGE = 32;
            public const int SF_NCRFORNONASCII = 64;
            public const int SF_RTFVAL = 0x0700;
            [DllImport("user32")]public static extern int SendMessage(HWND hwnd, int wMsg, int wParam, IntPtr lParam);
            [DllImport("user32")]public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
            //
            public delegate UInt32 EditStreamCallback(IntPtr dwCookie, IntPtr pbBuff, Int32 cb, IntPtr pcb);
    
            public struct EDITSTREAM
            {
                public IntPtr dwCookie;
                public UInt32 dwError;
                public EditStreamCallback pfnCallback;
            }
        }
    }
