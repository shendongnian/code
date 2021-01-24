    else
    {
        cm.Placement = PlacementMode.Custom;
        cm.PlacementTarget = sender as UIElement;
  
        cm.CustomPopupPlacementCallback = 
            (popupSize, targetSize, offset) => 
                new[] 
                { 
                    new CustomPopupPlacement 
                    { 
                        Point = new Point(targetSize.Width - popupSize.Width, targetSize.Height) 
                    } 
                };
              
        cm.IsOpen = true;
    }
