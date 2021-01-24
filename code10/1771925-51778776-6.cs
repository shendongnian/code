    public class Originator{
        private Series _series = new Series();
        public Originator() { }
        public Originator(Series series)
        {
            // _series = series;
            _series.Points.Clear();
            foreach (var dp in series.Points) _series.Points.Add(dp.Clone());
        }
        public Series OSeries
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
       
        public Memento SaveSeries()
        {
            return new Memento(_series);
        }
        public void RestoreSeries(Memento m)
        {
            //this._series = m.MMseries;
            
            this._series.Points.Clear();
            foreach (var dp in m.MMseries.Points) this._series.Points.Add(dp);
            this._series.ChartType = SeriesChartType.Line;
        }
       
