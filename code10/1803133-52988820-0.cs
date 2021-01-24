        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int totalSteps = lv_selection.Items.Count;
            int currentStep = 0;
            // Installations
            foreach (string p in lv_selection.Items)
            {
                currentStep++;
                // My long task 
                this.Dispatcher.Invoke(() =>
                {
                    progressbarForm.Progress(p);
                });
                (sender as BackgroundWorker).ReportProgress((int)(100 / totalSteps) * currentStep, null);
                }
        }
