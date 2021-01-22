    public class MyContextMenu : ContextMenu
    {
      override protected void Show (Control c, Point p)
      {
            if (this.MenuItems.Count == 0)
              base.Show (c, p) ;
              
            // else do nothing
      }
      override protected void (Control c, Point p, LeftRightAlignment z) 
      {
            if (this.MenuItems.Count == 0)
              base.Show (c, p, z) ;
              
            // else do nothing
      }
    }
