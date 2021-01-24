    private async void PerformTask_Click(object sender, EventArgs e) {
      try
      {
        await Task.Run(() => {
            foreach (var item in AnalyzeItems()) {
                ResultLog.Invoke((Action)delegate() { ResultLog.Text += item.ToString(); });
            }
        });
      }
      catch(Exception ex)
      {
        // handle...
      }
    }
