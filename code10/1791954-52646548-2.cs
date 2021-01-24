	public class Drone
	{
		public Drone()
		{
			var altitude = 0.0;
			var interval = TimeSpan.FromMilliseconds(200);
	
			IObservable<double> landing =
				Observable
					.Interval(interval)
					.TakeWhile(h => altitude > 0.0)
					.Select(t =>
					{
						altitude -= 10.0;
						altitude = altitude > 0.0 ? altitude : 0.0;
						return altitude;
					});
	
			IObservable<double> takeOff =
				Observable
					.Interval(interval)
					.TakeWhile(h => altitude < BaseAltitude)
					.Select(t =>
					{
						altitude += 10.0;
						altitude = altitude < BaseAltitude ? altitude : BaseAltitude;
						return altitude;
					});
	
			IObservable<double> cruise =
				Observable
					.Interval(interval)
					.Select(t =>
					{
						altitude = 10.0 * Math.Sin(t * 2.0 * Math.PI / 180.0) + BaseAltitude;
						return altitude;
					});
	
			this.Altitude =
				_isLandings
					.Select(x => x ? landing : takeOff.Concat(cruise))
					.Switch()
					.StartWith(altitude);
		}
	
		private bool _isLanding = true;
		private Subject<bool> _isLandings = new Subject<bool>();
	
		public bool IsLanding
		{
			get => _isLanding;
			set
			{
				_isLanding = value;
				_isLandings.OnNext(value);
			}
		}
	
		public double BaseAltitude { get; set; } = 100.0;
		public IObservable<double> Altitude { get; }
	}
