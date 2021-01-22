    private void PassPBName(ToolStripProgressBar PBName, AxSHDocVw.DWebBrowserEvents2_ProgressChangeEvent e)
        {
                  /* The CurrentProgress variable from the raised event
                  * gives you the current number of bytes already downloaded
                  * while the MaximumProgress is the total number of bytes
                  * to be downloaded */
            if (e.progress < e.progressMax)
            {
                // Check if the current progress in the progress bar
                // is >= to the maximum if yes reset it with the min
                if (PBName.Value >= PBName.Maximum)
                    PBName.Value = PBName.Minimum;
                else
                    // Just increase the progress bar
                    PBName.PerformStep();
            }
            else
                // When the document is fully downloaded
                // reset the progress bar to the min (0)
                PBName.Value = PBName.Minimum;
        }
        private void WBIntranet_ProgressChange(object sender, AxSHDocVw.DWebBrowserEvents2_ProgressChangeEvent e)
        {
            //Pass the PB bar name to PassPBName function to show current progress.
             PassPBName (PBIntranet, e);
        }
