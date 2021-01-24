    void UnlockPage()
    {
        if (lockPage == true)
        {
            LockPage = false;
        }
        else
        {
            LockPage = true;
        }
        OnPropertyChanged(nameof(LockPage));
    }
