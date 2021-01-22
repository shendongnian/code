    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class MyTextBox : TextBox {
      public MyTextBox() {
        this.SetStyle(ControlStyles.UserPaint, true);
      }
      protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        // Paint something
        //...
      }
    }
