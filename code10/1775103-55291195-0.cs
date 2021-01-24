csharp
	// You can render audio and video as it becomes available but the downside of disabling time
	// synchronization is that video and audio will run on their own independent clocks.
	// Do not disable Time Sync for streams that need synchronized audio and video.
	e.Options.IsTimeSyncDisabled =
		e.Info.Format == "libndi_newtek" ||
		e.Info.InputUrl.StartsWith("rtsp://uno");
	// You can disable the requirement of buffering packets by setting the playback
	// buffer percent to 0. Values of less than 0.5 for live or network streams are not recommended.
	e.Options.MinimumPlaybackBufferPercent = e.Info.Format == "libndi_newtek" ? 0 : 0.5;
	// The audio renderer will try to keep the audio hardware synchronized
	// to the playback position by default.
	// A few WMV files I have tested don't have continuous enough audio packets to support
	// perfect synchronization between audio and video so we simply disable it.
	// Also if time synchronization is disabled, the recommendation is to also disable audio synchronization.
	Media.RendererOptions.AudioDisableSync =
		e.Options.IsTimeSyncDisabled ||
		e.Info.InputUrl.EndsWith(".wmv");
