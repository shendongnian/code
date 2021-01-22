    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class RichTextBox5 : RichTextBox {
      private static IntPtr moduleHandle;
    
      protected override CreateParams CreateParams {
        get {
          if (moduleHandle == IntPtr.Zero) {
            moduleHandle = LoadLibrary("msftedit.dll");
            if ((long)moduleHandle < 0x20) throw new Win32Exception(Marshal.GetLastWin32Error(), "Could not load Msftedit.dll");
          }
          CreateParams createParams = base.CreateParams;
          createParams.ClassName = "RichEdit50W";
          if (this.Multiline) {
            if (((this.ScrollBars & RichTextBoxScrollBars.Horizontal) != RichTextBoxScrollBars.None) && !base.WordWrap) {
              createParams.Style |= 0x100000;
              if ((this.ScrollBars & ((RichTextBoxScrollBars)0x10)) != RichTextBoxScrollBars.None) {
                createParams.Style |= 0x2000;
              }
            }
            if ((this.ScrollBars & RichTextBoxScrollBars.Vertical) != RichTextBoxScrollBars.None) {
              createParams.Style |= 0x200000;
              if ((this.ScrollBars & ((RichTextBoxScrollBars)0x10)) != RichTextBoxScrollBars.None) {
                createParams.Style |= 0x2000;
              }
            }
          }
          if ((BorderStyle.FixedSingle == base.BorderStyle) && ((createParams.Style & 0x800000) != 0)) {
            createParams.Style &= -8388609;
            createParams.ExStyle |= 0x200;
          }
          return createParams;
        }
      }
      // P/Invoke declarations
      [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
      private static extern IntPtr LoadLibrary(string path);
    
    }
