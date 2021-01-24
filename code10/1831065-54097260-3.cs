<!-- -->
	Context.TrackPoints.Include("Track")
		.Where(_ => 
			_.Track.MinLongitude <= track.MaxLongitude &&
			_.Track.MaxLongitude >= track.MinLongitude &&
			_.Track.MinLatitude  <= track.MaxLatitude &&
			_.Track.MaxLatitude  >= track.MinLatitude)
		.ToList();
