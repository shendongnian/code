    public class FirstControl : Control{  
       public FirstControl() {}  
       protected override void OnPaint(PaintEventArgs e) {  
          // Call the OnPaint method of the base class.  
          base.OnPaint(e);  
          // Call methods of the System.Drawing.Graphics object.  
          e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle);  
       }   
    }   
