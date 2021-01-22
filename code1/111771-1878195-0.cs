    using System;
    using System.Windows.Forms;
    
    class MyWebBrowser : WebBrowser {
      protected override CreateParams CreateParams {
        get {
          var parms = base.CreateParams;
          parms.Style |= 0x800000;  // Turn on WS_BORDER
          return parms;
        }
      }
    }
