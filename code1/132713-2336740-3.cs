    protected override void OnPaint( PaintEventArgs e ) {
      Graphics g = e.Graphics;
      Brush b = new SolidBrush( this.ForeColor );
      SizeF sf = g.MeasureString( this.Text, this.Font );
      Padding p = Padding.Add( this.Padding, this.Margin );
      // do not forget to include the offset for you circle and text in the x, y position
      float x = p.Left;
      float y = p.Top;
      g.DrawString(  this.Text, this.Font, b, x, y );
    }
