	public static class AClassyClass
	{
		public static async Task SpeakUtteranceAsync(this AVSpeechSynthesizer synthesizer, AVSpeechUtterance speechUtterance, CancellationToken cancelToken)
		{
			var tcsUtterance = new TaskCompletionSource<bool>();
			try
			{
				synthesizer.DidFinishSpeechUtterance += OnFinishedSpeechUtterance;
				synthesizer.SpeakUtterance(speechUtterance);
				using (cancelToken.Register(TryCancel))
				{
					await tcsUtterance.Task;
				}
			}
			finally
			{
				synthesizer.DidFinishSpeechUtterance -= OnFinishedSpeechUtterance;
			}
			void TryCancel()
			{
				synthesizer?.StopSpeaking(AVSpeechBoundary.Word);
				tcsUtterance?.TrySetResult(true);
			}
			void OnFinishedSpeechUtterance(object sender, AVSpeechSynthesizerUteranceEventArgs args)
			{
				if (speechUtterance == args.Utterance)
					tcsUtterance?.TrySetResult(true);
			}
		}
	}
