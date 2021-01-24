        private void STOPButton_Clicked(object sender, EventArgs e)
        {
            startButton.IsVisible = true;
            //hides stop button
            stopButton.IsVisible = false;
            //stops timer
            if (this.cancellation != null)
		        Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();
            shouldRun = false;
        }
    
