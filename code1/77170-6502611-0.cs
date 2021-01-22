    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace MyControls
    {
      // Apply ToolboxBitmap attribute here
      public class CustomTextBox : TextBox
      {
        public CustomTextBox()
        {
          BorderStyle = BorderStyle.None;
        }
    
        [DefaultValue(typeof(System.Windows.Forms.BorderStyle),"None")]
        public new BorderStyle BorderStyle
        {
          get { return base.BorderStyle; }
          set { base.BorderStyle = value; }
        }
      }
    }
