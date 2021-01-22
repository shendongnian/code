    public bool GetCapability(Caps cap) { 
       return IsLoggedIn && CapabilityResolver.Check(CurrentPresenter, cap);
       // or even
       // return CapabilityResolver.Check(CurrentPresenter, cap, IsLoggedIn);
    }
    // usage
    whatever.GetCapability(Caps.CanGoHome);
