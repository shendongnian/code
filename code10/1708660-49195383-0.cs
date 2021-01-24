    // To get around the progressive animation, we need to move the 
    // progress bar backwards.
    if (value == pb.Maximum)
    {
        // Special case as value can't be set greater than Maximum.
        pb.Maximum = value + 1;     // Temporarily increase Maximum
        pb.Value = value + 1;       // Move past
        pb.Maximum = value;         // Reset maximum
    }
    else
    {
        pb.Value = value + 1;       // Move past
    }
    pb.Value = value; 
