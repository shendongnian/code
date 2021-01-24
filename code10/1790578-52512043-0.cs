    // the buffer to save frames that need to be processed:
    private readonly BufferBlock<ImageFrame> buffer = new BufferBlock<ImageFrame>();
    // event handler to be called whenever the camera has an image
    // similar like your ProcessFrame
    public async void OnImageAvailableAsync(object sender, EventArgs e)
    {
        // the sender is your camera who reports that an image can be grabbed:
        ImageGrabber imageGrabber = (ImageGrabber)sender;
        // grab the image:
        ImageFrame grabbedFrame = imageGrabber.QueryFrame();
        // save it on the buffer for processing:
        await this.buffer.SendAsync(grabbedFrame);
        // finished producing the image frame
    }
