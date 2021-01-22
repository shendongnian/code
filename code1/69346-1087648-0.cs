    if (this.Parent != null)
    {
     GraphicsContainer cstate = pevent.Graphics.BeginContainer();
     pevent.Graphics.TranslateTransform(-this.Left, -this.Top);
     Rectangle clip = pevent.ClipRectangle;
     clip.Offset(this.Left, this.Top);
     PaintEventArgs pe = new PaintEventArgs(pevent.Graphics, clip);
     //paint the container's bg
     InvokePaintBackground(this.Parent, pe);
     //paints the container fg
     InvokePaint(this.Parent, pe);
     //restores graphics to its original state
     pevent.Graphics.EndContainer(cstate);
    }
    else
      base.OnPaintBackground(pevent); // or base.OnPaint(pevent);...
