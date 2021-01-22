        /// <summary>
        /// Delegate to notify UI thread of worker thread progress.
        /// </summary>
        /// <param name="total">The total to be downloaded.</param>
        /// <param name="downloaded">The amount already downloaded.</param>
        public delegate void UpdateProgressDelegate(int total, int downloaded);
        /// <summary>
        /// Updates the progress in a thread-safe manner.
        /// </summary>
        /// <param name="total">The total.</param>
        /// <param name="downloaded">The downloaded.</param>
        public void UpdateProgress(int total, int downloaded)
        {
            // Check we are on the right thread.
            if (!this.InvokeRequired)
            {
                this.ProgressBar.Maximum = total;
                this.ProgressBar.Value = downloaded;
            }
            else
            {
                if (this != null)
                {
                    UpdateProgressDelegate updateProgress = new UpdateProgressDelegate(this.UpdateProgress);
                    // Executes a delegate on the thread that owns the control's underlying window handle.
                    this.Invoke(updateProgress, new object[] { total, downloaded });
                }
            }
        }
