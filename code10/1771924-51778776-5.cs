    public class Memento
    {
        private Series _series =new Series();
        public Memento(Originator org)
        {
            this._series.Points.Clear();
            foreach (var dp in org.OSeries.Points) this._series.Points.Add(dp.Clone());
        }
        public Memento(Series mseries)
        {
            this._series.Points.Clear();
            foreach (var dp in mseries.Points) this._series.Points.Add(dp.Clone());
        }
            
        public Series MMseries
        {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
            }
        }
    }
