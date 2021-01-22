    void AllControls(Control root, List<Control> accumulator)
    {
        accumulator.Add(root);
        foreach(Control ctrl in root.Controls)
        {
            AllControls(ctrl, accumulator);
        }
    }
