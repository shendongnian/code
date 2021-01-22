    // contrived example...
    private void Swap( Control toAdd, Control toRemove )
    {
        this.Controls.Remove( toRemove );
        this.Controls.Add( toAdd );
    }
