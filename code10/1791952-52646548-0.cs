	public class Drone
	{
		public Drone()
		{
			this.Altitude = ...
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
