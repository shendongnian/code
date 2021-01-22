    public class MyECGDrawer : Control
    {
    protect override OnPaint(PaintEventArgs pe )
    {
       // refresh background
        pe.Graphics.FillRectangle( Brushes.White, 0, 0, Width, Height );
        int prevX = -1, prevY = -1;
        for(int x = 0; x < Width; x++ )
        {
            if( prevX >= 0 )
                pe.Graphics.DrawLine( Pens.Black, prevX, prevY, x, Math.sin(x) );
            prevX = x;
            prevY = Math.sin(x);
        }
    }
    }
