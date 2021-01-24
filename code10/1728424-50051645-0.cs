    public void subFormLauncher<T>(object sender, T f) where T : SubForm 
    {
        if (f == null)
        {
            f = new T(this);    // This line is problematic
            f.Show();
        }
        else
        {
            if (!f.Visible)
            {
                f.Show();
            }
            f.Activate();
        }
    }
