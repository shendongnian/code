    public bool CheckControls()
    {
        bool pass = true;
        pass &= !string.IsNullOrEmpty(authorbox.Text));
        pass &= !string.IsNullOrEmpty(titlebox.Text));
        // if any of these are empty then pass is to false and stays that way.
        return pass;
    }
