    using System;
    using System.Drawing;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    public class MyListBox : ListBox {
      private Control mParent;
      private Point mPos;
      private bool mInitialized;
    
      public MyListBox(Control parent) {
        mParent = parent;
        mInitialized = true;
        this.SetTopLevel(true);
        parent.LocationChanged += new EventHandler(parent_LocationChanged);
        mPos = mParent.Location;
      }
    
      public new Point Location {
        get { return mParent.PointToClient(this.Location); }
        set { 
          Point zero = mParent.PointToScreen(Point.Empty);
          base.Location = new Point(zero.X + value.X, zero.Y + value.Y);
        }
      }
    
      protected override Size DefaultSize {
        get {
          return mInitialized ? base.DefaultSize : Size.Empty;
        }
      }
    
      protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) {
        if (this.mInitialized)
          base.SetBoundsCore(x, y, width, height, specified);
      }
    
      void parent_LocationChanged(object sender, EventArgs e) {
        base.Location = new Point(base.Left + mParent.Left - mPos.X, base.Top + mParent.Top - mPos.Y);
        mPos = mParent.Location;
      }
    
      protected override CreateParams CreateParams {
        get {
          CreateParams cp = base.CreateParams;
          if (mParent != null && !DesignMode) {
            cp.Style = (int)(((long)cp.Style & 0xffff) | 0x90200000);
            cp.Parent = mParent.Handle;
            Point pos = mParent.PointToScreen(Point.Empty);
            cp.X = pos.X;
            cp.Y = pos.Y;
            cp.Width = base.DefaultSize.Width;
            cp.Height = base.DefaultSize.Height;
          }
          return cp;
        }
      }
    }
