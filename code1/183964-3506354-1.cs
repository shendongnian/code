    public void SetClipboard(object newValue)
    {
        if (!_userInitiated)
            return;    // or throw AccessDeniedException?
        // set clipboard here
    }
