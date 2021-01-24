        CancellationTokenSource tokenSource;
 		private void btnStart_Click(object sender, RoutedEventArgs e)
		{
			txt_importStatus.Text = "";
			var progress = new Progress<string>(progress_info =>
			{
				//show import progress on a textfield
				txt_importStatus.Text = progress_info + Environment.NewLine + "Please dont close this window while the system processing the excel file contents";              
			});
			// DoProcessing is run on the thread pool.
            tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
			await Task.Run(() => DoProcessing(token, progress));
		}
