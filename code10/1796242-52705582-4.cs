    int minSize = new IList[] {time_elapsed, speed_x, speed_y, speed_z}.Min(c => c.Count);
    IEnumerable<Status> statuses = Enumerable.Range(0, minSize)
		.Select(i => new Status
		{
			TimeElapsed = time_elapsed[i],
			SpeedX = speed_x[i],
			SpeedY = speed_y[i],
			SpeedZ = speed_z[i],
		});
