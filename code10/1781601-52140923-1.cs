    var enumerator = controls.GetEnumerator();
    if (enumerator.MoveNext())
    {   // there is at least one control
        Control smallestControl = enumerator.Current;
        int smallestSize = smallestControl.GetSize();
        // continue enumerating the other controls, to see if they are smaller
        while (enumerator.MoveNext())
        {   // there are more controls
            control enumerator.Current;
            size = control.GetSize();
            if (size < smallestSize)
            {   // this control is smaller
                smallestControl = control;
                smallestSize = size;
            }
        }
    }
