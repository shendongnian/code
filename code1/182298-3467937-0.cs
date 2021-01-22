        private void changeProgressBar()
        {
            (new Task(() =>
            {
                mainProgressBar.Value++;
                mainProgressTextField.Text = mainProgressBar.Value + " of " + mainProgressBar.Maximum;
            })).Start(uiScheduler);
        }
