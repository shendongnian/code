    //A small change in the "Max's" answer to stop the repeatedly call.
    //this line to stop the repeatedly call
    ScrollViewer.CanContentScroll="False"
    
    private void dtGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
                    {
    //this is for vertical check & will avoid the call at the load time (first time)
                        if (e.VerticalChange > 0)
                        {
                            if (e.VerticalOffset + e.ViewportHeight == e.ExtentHeight)
                            {
                                // Do your Stuff
                            }
                        }
                    }
