    private void UpdateFromBackground()
    {
        if (this.BackgroundImage != null)
        {
           this.BackgroundImage.Dispose();
        }
        this.BackgroundImage = MakeCustomBackground();
    }
