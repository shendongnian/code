    private void btntarget_MouseDown(object sender, MouseEventArgs e)
        {                                
           
            Bitmap bmp = new Bitmap(btntarget.Width, btntarget.Height);
            btntarget.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
 	        //optionally define a transparent color
	        bmp.MakeTransparent(Color.White);
            Cursor cur = new Cursor(bmp.GetHicon());                                
            Cursor.Current = cur;            
        }
