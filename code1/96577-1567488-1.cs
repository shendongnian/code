    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    class OutClipboard {
      [STAThread]
      static void Main() {
        Clipboard.SetText(Console.In.ReadToEnd());
      }
    }
