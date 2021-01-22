    public class MyContextMenu : ContextMenu
    {
      override protected void OnPopUp(EventArgs e)
      {
            if (this.MenuItems.Count > 0)
              base.OnPopUp(e);
              
            // else do nothing
      }
    }
