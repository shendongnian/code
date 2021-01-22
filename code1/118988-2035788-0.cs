        private void SomethingCalledFromBackgroundThread()
        {
            panel1.Invoke(new DoUpdatePanel(UpdatePanel), Color.Blue);
        }
        private delegate void DoUpdatePanel(Color aColor);
        private void UpdatePanel(Color aColor)
        {
            panel1.BackColor = aColor;
        }
