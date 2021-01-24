	var timer = new System.Timers.Timer()
	timer.Interval = 60000;
	timer.Elapsed += (_s, _e) =>
	{
		/* pull pull out the next frame */
		has.pullFrame();
		/* does the device have more frames */
		if (has.isFrameEmpty())
			timer.Enabled = false;;
		// REST OF YOUR LOOP CODE HERE
	};
	timer.Enabled = true;
	
