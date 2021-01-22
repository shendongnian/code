    private void object_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
    {
        ...
        // If this was a multitouch gesture 
        // (like pinch/zoom - indicated by e.DeltaManipulation.Scale)
        // the following line will get us point between fingers.
        Point position = e.ManipulationOrigin;
        ...
    }
