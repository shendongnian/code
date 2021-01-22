    object ret;
    // Do common stuff
    if (type == typeof(ProfileNodeCollection))
    {
        ProfileNodeCollection nodes = new ProfileNodeCollection();
        // Logic to build nodes
        ret = nodes;
    }
    else
    {
        TreeNodeCollection nodes = new TreeNodeCollection();
        Logic to build nodes
        ret = nodes;
    }
    return (T)ret;
