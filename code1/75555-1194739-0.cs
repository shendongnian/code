        //Create a Delegate to update your status button
        delegate void StringParameterDelegate(string value);
        String countLabel = "/" + count.ToString();
        //When your button is clicked to process the loops, start a thread for process the loops
        public void StartProcessingButtonClick(object sender, EventArgs e)
        {
            Thread queryRunningThread = new Thread(new ThreadStart(ProcessLoop));
            queryRunningThread.Name = "ProcessLoop";
            queryRunningThread.IsBackground = true;
            queryRunningThread.Start();
        }
        private void ProcessLoop()
        {
            for (i = 0; i < count; i++)
            {
                ... do analysis ...
                UpdateProgressLabel("Step "+i.ToString()+countLabel);
            }
        }
        void UpdateProgressLabel(string value)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UpdateProgressLabel), new object[] { value });
                return;
            }
            // Must be on the UI thread if we've got this far
            labelProgress.Content = value;
        }
