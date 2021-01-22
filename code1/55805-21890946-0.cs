            protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    		{
    			this._IsDragInProgress = true;
    			this.CaptureMouse();
    			this._FormMousePosition = e.GetPosition((UIElement)this);
    			base.OnMouseLeftButtonDown(e);
    		}
    
    		protected override void OnMouseMove(MouseEventArgs e)
    		{
    			if (!this._IsDragInProgress)
    				return;
    
    			System.Drawing.Point screenPos = (System.Drawing.Point)System.Windows.Forms.Cursor.Position;
    			double top = (double)screenPos.Y - (double)this._FormMousePosition.Y;
    			double left = (double)screenPos.X - (double)this._FormMousePosition.X;
    			this.SetValue(MainWindow.TopProperty, top);
    			this.SetValue(MainWindow.LeftProperty, left);
    			base.OnMouseMove(e);
    		}
    
    		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    		{
    			this._IsDragInProgress = false;
    			this.ReleaseMouseCapture();
    			base.OnMouseLeftButtonUp(e);
    		}
