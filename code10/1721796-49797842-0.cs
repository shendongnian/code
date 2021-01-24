    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        if (e.StatusType == GestureStatus.Started)
        {
            this.xOffset = this.Content.TranslationX;
            this.yOffset = this.Content.TranslationY;
        }
        if (e.StatusType != GestureStatus.Completed
            && e.StatusType != GestureStatus.Canceled)
        {
            this.Content.TranslationX = this.xOffset + e.TotalX;
            this.Content.TranslationY = this.yOffset + e.TotalY;
        }
        if (e.StatusType == GestureStatus.Completed)
        {
            this.xOffset = this.Content.TranslationX;
            this.yOffset = this.Content.TranslationY;
        }
    }
