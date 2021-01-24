    bool? blinking = ctrl.Tag as bool?;
    Stopwatch sw;
    if (!blinking ?? false)
    {
        ctrl.Tag = true;
        sw = new Stopwatch();
        while(true)
        {
            // do stuff
        }
        ctrl.Tag = false; // doesn't look like you would ever reach this point.
    }
