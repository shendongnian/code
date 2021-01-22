        private void MainForm_Load(object sender, EventArgs e)
        {
                MeasuredParamEditor.CollectionChanged += new EventHandler(OnMeasuredParamsChanged); 
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MeasuredParamEditor.CollectionChanged -= new EventHandler(OnMeasuredParamsChanged);
        }
        void OnMeasuredParamsChanged(object sender, EventArgs e)
        {
            this.myPropGrid.Refresh();
        }
