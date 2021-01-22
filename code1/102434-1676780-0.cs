    void ChangeEnabled( bool enabled )
    {
        foreach ( Control c in this.Controls )
        {
            c.Enabled = enabled;    
        }
    }
