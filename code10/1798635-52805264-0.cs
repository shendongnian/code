    public class JoinedProgressBar
    {
        private List<ProgressBar> _progressBars;
        public JoinedProgressBar(List<ProgressBar> progressBars)
        {
            _progressBars = progressBars ?? new List<ProgressBar>();
        }
        public void UpdateBarsPercent(int value)
        {
            UpdateBars(value * GetSum() / 100);
        }
        public void UpdateBars(int value)
        {
            var remaining = value;
            for(int i = 0; i < _progressBars.Count; i++)
            {
                _progressBars[i].Value = 
                    remaining <= _progressBars[i].Minimum ? _progressBars[i].Minimum :
                    remaining >= _progressBars[i].Maximum ? _progressBars[i].Maximum : remaining;
                remaining -= _progressBars[i].Maximum;
            }
        }
        public int GetSum()
        {
            var bars = _progressBars.Select(pb => pb.Maximum - pb.Minimum).ToList();
            return bars.Count > 0 ? bars.Sum() : 0;
        }
    }
