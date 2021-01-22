    void OnMadeSound()
    {
        if (MadeSound != null)
        {
            MadeSound(this, new EventArgs());
        }
    }
    
    public void Fall() {  OnMadeSound(); }
