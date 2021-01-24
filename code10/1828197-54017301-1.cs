    var splitted= target.Split(':')[0] + ": ";
    if (_Timing != splitted)
    {
       _Timing = splitted;
       splitted = null;
       GC.Collect(); // It this stage the 'splitted' is not longer remain in the memory.
    }
