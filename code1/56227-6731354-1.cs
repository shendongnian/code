    // Enumerate all the descendants of the visual object.
    static public void EnumVisual(Visual myVisual)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
        {
            // Retrieve child visual at specified index value.
            Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
    
            // Do processing of the child visual object.
    
            // Enumerate children of the child visual object.
            EnumVisual(childVisual);
        }
    }
