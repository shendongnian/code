	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		progressBar1.Invoke((Action) (() =>
			{
				progressBar1.MarqueeAnimationSpeed = 0;
				progressBar1.Style = ProgressBarStyle.Continuous;
			}));
	}
