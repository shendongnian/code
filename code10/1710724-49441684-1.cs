    AudioRecorderService AudioRecorder { get; } = new AudioRecorderService
	{
		StopRecordingOnSilence = true,
        PreferredSampleRate = 16000
	});
	public async Task StartRecording()
	{
		AudioRecorder.AudioInputReceived += HandleAudioInputReceived;
		await AudioRecorder.StartRecording();
	}
    public async Task StopRecording()
    {
		AudioRecorder.AudioInputReceived += HandleAudioInputReceived;
		await AudioRecorder.StartRecording();
    }
	async void HandleAudioInputReceived(object sender, string e)
	{
		AudioRecorder.AudioInputReceived -= HandleAudioInputReceived;
        PlaybackRecording();
        //replace [UserGuid] with your unique Guid
        await EnrollSpeaker(AudioRecorder.GetAudioFileStream(), [UserGuid]);
	}
