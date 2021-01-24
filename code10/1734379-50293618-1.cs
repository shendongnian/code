    {
        int x = IsLocked.get();
        if (x == 1) {
            locked.Visible = true;
            unlocked.Visible = false;
        } else {
            locked.Visible = false;
            unlocked.Visible = true;
        }
    }
