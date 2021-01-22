    using MediaToolkit;
    // a method to get Width, Height, and Duration in Ticks for video.
	public static Tuple<int, int, long> GetVideoInfo(string fileName)
	{
		var inputFile = new MediaToolkit.Model.MediaFile { Filename = fileName };
		using (var engine = new Engine())
		{
			engine.GetMetadata(inputFile);
		}
    
        // FrameSize is returned as '1280x768' string.
        var size = inputFile.Metadata.VideoData.FrameSize.Split(new[] { 'x' }).Select(o => int.Parse(o)).ToArray();
		return new Tuple<int, int, long>(size[0], size[1], inputFile.Metadata.Duration.Ticks);
	}
