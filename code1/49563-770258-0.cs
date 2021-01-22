    Control root = ((Control)e.CommandSource);
    while(root.Parent != null)
    {
        // must start with the parent
        root = root.Parent;
        if (root is RadGrid)
        {
            // stop at the first grid parent
            break;
        }
    }
    // might throw exception if there was no parent that was a RadGrid
    RadGrid gv = (RadGrid)root;
