      public class TransparentPanel : Panel
      {
        protected override CreateParams CreateParams
        {
          get
          {
            var cp = base.CreateParams;
            cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
            return cp;
          }
        }
      }
