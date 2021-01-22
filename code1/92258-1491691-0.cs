    public class MyUserControl : UserControl{
    
      private SolidBrush _brush;
    
      public MyUserControl() {
        _brush = new SolidBrush(Color.Red);
      }
    
      protected override void OnPaint(PaintEventArgs e){
        // Draw with the brush;
      }
    
      protected override void Dispose(bool disposing){
        // other Dispose logic
        if (_brush != null) {
          _brush.Dispose();
        }
      }
    }
