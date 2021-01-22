        public void ShowWithDetails(double Counter, double Narrow, double Broad)
        {
            CounterLabel.Text = Counter.ToString();
            NarrowLabel.Text = Narrow.ToString();
            BroadLabel.Text = Broad.ToString();
            ShowDialog();
        }
