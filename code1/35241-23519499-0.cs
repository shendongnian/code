        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        using System.Reflection;
    
        using System.Drawing.Text;
    
        namespace WindowsFormsApplication1
        {
            public partial class Form1 : Form
            {
                [System.Runtime.InteropServices.DllImport("gdi32.dll")]
                private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
                    IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
                private PrivateFontCollection fonts = new PrivateFontCollection();
                Font myFont;
                public Form1()
                {
                    InitializeComponent();
    
                    byte[] fontData = Properties.Resources.MyFontName;
                    IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
                    System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                    uint dummy = 0;
                    fonts.AddMemoryFont(fontPtr, Properties.Resources.MyFontName.Length);
                    AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.MyFontName.Length, IntPtr.Zero, ref dummy);
                    System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
    
                    myFont = new Font(fonts.Families[0], 16.0F);
                }
            }
        }
