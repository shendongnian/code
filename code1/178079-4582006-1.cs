    public void Destroy()
    {
        // Remove any handlers from the iTunes COM object.
        itunes.OnPlayerPlayEvent -= itunes_OnPlayerPlayEvent;
        // Release the COM object.
        Marshal.ReleaseComObject(itunes);
    }
