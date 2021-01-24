    bool playingVideo = false;
	Timer frameTimer = new Timer(this.GrabFrame, null, 0, 1000 / 33);
    private void btnPlay_Click(object sender, EventArgs e)
    {
		playingVideo = true;
	}
	
	
    private void GrabFrame(object sender, EventArgs e)
    {
		if(playingVideo)
		{
		    while (currentFrameNo<totalFrames)
			{
				imageBox1.Image = videoCapture.QueryFrame();
				currentFrameNo += 1;
			}
		}
    }
