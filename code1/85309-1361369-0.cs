    private enum Direction
    {
        Next,
        Previous
    }
    
    private void SwapLocations(Control current, Direction direction)
    {
        if (current == null)
        {
            throw new ArgumentNullException("current");
        }
        // get the parent
        Control parent = current.Parent;
        // forward or backward?
        bool forward = direction == Direction.Next;
        // get the next control in the given direction
        Control next = parent.GetNextControl(current, forward);
        if (next == null)
        {
            // we get here, at the "end" in the given direction; we want to
            // go to the other "end"
            next = current;
            while (parent.GetNextControl(next, !forward) != null)
            {
                next = parent.GetNextControl(next, !forward);
            }
        }
        // get the indices for the current and next controls
        int nextIndex = parent.Controls.IndexOf(next);
        int currentIndex = parent.Controls.IndexOf(current);
    
        // swap the indices
        parent.Controls.SetChildIndex(current, nextIndex);
        parent.Controls.SetChildIndex(next, currentIndex);
    }
