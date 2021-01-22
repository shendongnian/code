    void contextRightMenu_Popup(object sender, EventArgs e)
    {
      ContextMenu menu = sender as ContextMenu;
      if (menu != null)
      {
        // Get cursor position in screen coordinates
        Point screenPoint = Cursor.Position;
        // Convert screen coordinates to a point relative to the control
        // that was right clicked, in your case this would be the relavant 
        // picture box.
        Point pictureBoxPoint = menu.SourceControl.PointToClient(screenPoint);
      }
    }
