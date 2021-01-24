    private IDictionary<string, int> soundDict = new Dictionary<string, int>();
	public Task<string> LoadSounds(IEnumerable<string> fileNames)
	{
		var sounds = fileNames
			.Select(name =>
			{
				var snd = new
				{
					id = soundDict.Count,
					path = name
				};
				soundDict.Add(name, snd.id);
				return snd;
			})
			.ToList();
		return JSRuntime.Current.InvokeAsync<string>(
			"JsSound.loadSounds"
			, sounds
		);
	}
	public Task<string> Play(string name)
	{
		return JSRuntime.Current.InvokeAsync<string>(
			"JsSound.play"
			, soundDict[name]
		);
	}
