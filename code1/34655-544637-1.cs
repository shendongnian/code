    private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
      bool bold=false;
      bool regular=false;
      bool italic=false;
 
      e.Graphics.PageUnit=GraphicsUnit.Point;
      SolidBrush b = new SolidBrush(Color.Black);
 
      float y=5;
 
      System.Drawing.Font fn;
 
      foreach(FontFamily ff in pfc.Families)
      {
        if(ff.IsStyleAvailable(FontStyle.Regular))
        {
          regular=true;
          fn=new Font(ff,18,FontStyle.Regular);
          e.Graphics.DrawString(fn.Name,fn,b,5,y,StringFormat.GenericTypographic);
          fn.Dispose();
          y+=20;
        }
        if(ff.IsStyleAvailable(FontStyle.Bold))
        {
          bold=true;
          fn=new Font(ff,18,FontStyle.Bold);
          e.Graphics.DrawString(fn.Name,fn,b,5,y,StringFormat.GenericTypographic);
          fn.Dispose();
          y+=20;
        }
        if(ff.IsStyleAvailable(FontStyle.Italic))
        {
          italic=true;
          fn=new Font(ff,18,FontStyle.Italic);
          e.Graphics.DrawString(fn.Name,fn,b,5,y,StringFormat.GenericTypographic);
          fn.Dispose();
          y+=20;
        }
        if(bold  && italic)
        {
          fn=new Font(ff,18,FontStyle.Bold | FontStyle.Italic);
          e.Graphics.DrawString(fn.Name,fn,b,5,y,StringFormat.GenericTypographic);
          fn.Dispose();
          y+=20;
        }
        fn=new Font(ff,18,FontStyle.Underline);
        e.Graphics.DrawString(fn.Name,fn,b,5,y,StringFormat.GenericTypographic);
        fn.Dispose();
        y+=20;
        fn=new Font(ff,18,FontStyle.Strikeout);
        e.Graphics.DrawString(fn.Name,fn,b,5,y,StringFormat.GenericTypographic);
        fn.Dispose();
      }
 
      b.Dispose();
    }
