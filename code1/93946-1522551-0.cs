    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    
    namespace WindowsFormsApplication6
    {
    
      public partial class Form1 : Form
      {
    
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
      public IntPtr hIcon;
      public IntPtr iIcon;
      public uint dwAttributes;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
      public string szDisplayName;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
      public string szTypeName;
    };
    
    class Win32
    {
      public const uint SHGFI_ICON = 0x100;
      public const uint SHGFI_LARGEICON = 0x0;    
      public const uint SHGFI_SMALLICON = 0x1;    
    
      [DllImport("shell32.dll")]
      public static extern IntPtr SHGetFileInfo(string pszPath,
                                  uint dwFileAttributes,
                                  ref SHFILEINFO psfi,
                                  uint cbSizeFileInfo,
                                  uint uFlags);
    }
    
        private void button1_Click(object sender, EventArgs e)
        {
          string fName;     
          SHFILEINFO shinfo = new SHFILEINFO();
          OpenFileDialog openFileDialog1 = new OpenFileDialog();
          openFileDialog1.Filter = "All files (*.*)|*.*";
          openFileDialog1.FilterIndex = 2;
          openFileDialog1.RestoreDirectory = true;
    
          if (openFileDialog1.ShowDialog() == DialogResult.OK)
          {
            fName     = openFileDialog1.FileName;
            Win32.SHGetFileInfo(fName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
            System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
            pictureBox1.Image=(Image) myIcon.ToBitmap();
          }
    
        }
    
    
        public Form1()
        {
          InitializeComponent();
        }
      }
    }
