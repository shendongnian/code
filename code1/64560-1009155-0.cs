    private Rectangle _DragRect;
    
    private void MyDragSource_MouseDown(object sender, MouseEventArgs e) {
       Size dragsize = SystemInformation.DragSize;
       _DragRect = new Rectangle(new Point(e.X - (dragsize.Width / 2), e.Y - (dragsize.Height / 2)), dragsize);
    }
    
    private void MyDragSource_MouseMove(object sender, MouseEventArgs e) {
       if (e.Button == MouseButtons.Left) {
          if (_DragRect != Rectangle.Empty && !_DragRect.Contains(e.X, e.Y)) { 
             // the mouse has moved outside of the drag-rectangle.  Start drag operation
    
             MyDragSource.DoDragDrop(.....)
          }
       }
    }
    
    private void MyDragSource_MouseUp(object sender, MouseEventArgs e) {
       _DragRect = Rectangle.Empty; // reset
    }
