    using System.Runtime.InteropServices;
    public class RichBox : RichTextBox {
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      private static extern IntPtr LoadLibrary(string lpFileName);
      protected override CreateParams CreateParams {
        get {
          var cp = base.CreateParams;
          if (LoadLibrary("msftedit.dll") != IntPtr.Zero) {
            cp.ClassName = "RICHEDIT50W";
          }
          return cp;
        }
      }
    }
