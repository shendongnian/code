    void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // Trigger the implemented event, if not null.
        onIndexChanged?.Invoke(sender, e);
    }
