    // dont do this
    Toggle.IsChecked = registry.GetValue("AppName") == null ? false : true;
    // do this instead
    if (Toggle.IsChecked == true) // registry is apparently not null
    {
        // double check
        if (registry.GetValue("AppName") != null)
        {
            // registry is not null
            bRegistryIsEmpty = false;
        }
    }
    else // registry is apparently null
    {
        // double check
        if (registry.GetValue("AppName") == null)
        {
            // registry is null
            bRegistryIsEmpty = true;
        }
    }
    // or just do this
    bRegistryIsEmpty = registry.GetValue("AppName") == null ? true : false;
