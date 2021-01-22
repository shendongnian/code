    private void OnLayoutUpdated(object sender, EventArgs e)
                {
                    if (!isInitialized && this.ActualWidth != 0 && this.ActualHeight != 0)
                    {
                        isInitialized = true;
                        // Logic here
                    }
                };
