    public bool GetCapability(Caps cap) { 
       return IsLoggedIn && CapabilityResolver.Check(CurrentPresenter, cap);
    }
    // usage
    whatever.GetCapability(Caps.CanGoHome);
