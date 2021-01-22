        int runCount = 0;
        private void bindChart()
        {
            ObservableCollection<KeyValuePair<DateTime, int>> data = new ObservableCollection<KeyValuePair<DateTime, int>>();
            if (runCount == 0)
            {
                this.DataContext = dataEmpty;
            }
            else
            {
                var de = this.DataContext as ObservableCollection<KeyValuePair<DateTime, int>>;
                de.Clear();
                for (var i = 0; i < (new Random(DateTime.Now.Second)).Next(100); i++)
                {
                    de.Add(new KeyValuePair<DateTime, int>(DateTime.Today.AddDays(i), i));
                }
            }
            runCount++;
        } 
