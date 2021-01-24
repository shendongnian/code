	public class MainViewModel : ObservableObject
	{
		private IEnumerable<DataPointViewModel> _DataPoints;
		public IEnumerable<DataPointViewModel> DataPoints
		{
			get { return this._DataPoints; }
			set { Set(() => this.DataPoints, ref this._DataPoints, value); }
		}
		public int ChartWidth { get; } = 1000;
		public int ChartHeight { get; } = 1000;
		public MainViewModel()
		{
			var rng = new Random();
			this.DataPoints = Enumerable.Range(0, this.ChartWidth)
				.Select(x => new DataPointViewModel {X1 = x, Y1 = this.ChartHeight-1, X2 = x, Y2 = this.ChartHeight - 1 - rng.Next(this.ChartHeight) });
		}
	}
