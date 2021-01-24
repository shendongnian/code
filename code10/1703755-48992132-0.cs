    rect.ContextMenu.PlacementTarget = rect;
            
    rect.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
    rect.ContextMenu.IsOpen = true;
    // if you want it to be at the top and come down over the rectangle
    rect.ContextMenu.VerticalOffset = rect.ContextMenu.ActualHeight;
