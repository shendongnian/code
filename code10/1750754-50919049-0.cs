    public delegate void VideoSelectedHandler(object sender, VideoSelectionArgs e);
    public event VideoSelectedHandler VideoSelected;
    private void RaiseVideoSelectedEvent(MediaSource source)
    {         
        // Ensure that something is listening to the event.
        if (this.VideoSelected != null)
        {
            // Create the args, and call the listening event handlers.
            VideoSelectionArgs args = new VideoSelectionArgs(source);
            this.VideoSelected(this, args);
        }
    }
