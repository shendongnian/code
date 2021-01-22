        delegate void SetResultsTextCallback(string text);
        delegate string GetIterationCountCallback();
        private void SetResultsText(string text)
        {
            if (this.ResultsBox.InvokeRequired)
            {
                var d = new SetResultsTextCallback(SetResultsText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ResultsBox.Text = text;
            }
        }
        private string GetIterationCount()
        {
            if (this.RepetitionSelector.InvokeRequired)
            {
                var del = new GetIterationCountCallback(GetIterationCount);
                IAsyncResult result = del.BeginInvoke(null, null);
                return del.EndInvoke(result);
            }
            else
            {
                return RepetitionSelector.SelectedItem.ToString();
            }
        }
