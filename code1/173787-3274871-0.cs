    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
      class HotKey : Control  
      {
        public HotKey()
        {
          SetStyle(ControlStyles.UserPaint, false);
        }
        protected override CreateParams CreateParams
        {
          get
          {
            CreateParams cp = base.CreateParams;
            cp.ClassName = "msctls_hotkey32";
        
            return cp;
          }
        }
      }
    }
