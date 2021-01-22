    private PowerPoint.CustomLayout DpGetCustomLayout(
            PowerPoint.Presentation ppPresentation, string myLayout)
    {
       //
       // Given a custom layout name, find the layout in the master slide and return it
       // Return null if not found
       //
       PowerPoint.CustomLayout ppCustomLayout = null;
    
       for (int i = 0; i < ppPresentation.SlideMaster.CustomLayouts.Count; i++)
       {
           if (ppPresentation.SlideMaster.CustomLayouts[i + 1].Name == myLayout)
               ppCustomLayout = ppPresentation.SlideMaster.CustomLayouts[i + 1];
       }
          return ppCustomLayout;
    }
