    private async void UpdateUI(long lineCount)
    {
        await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
           // This time check prevents the UI from updating so frequently
           //    that it becomes unresponsive as a result.
           DateTime now = DateTime.Now;
           if ((now - this.LastUpdate).Milliseconds > 3000)
           {
               // This updates a textblock to display the count, but could also
               //    update a progress bar or progress ring in here.
               this.MessageTextBlock.Text = "Count: " + lineCount;
               this.LastUpdate = now;
           }
        });
    }
