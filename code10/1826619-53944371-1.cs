	public class DataPointViewModel : ObservableObject
	{
		private double _X1;
		public double X1
		{
			get { return this._X1; }
			set { Set(() => this.X1, ref this._X1, value); }
		}
		private double _Y1;
		public double Y1
		{
			get { return this._Y1; }
			set { Set(() => this.Y1, ref this._Y1, value); }
		}
		private double _X2;
		public double X2
		{
			get { return this._X2; }
			set { Set(() => this.X2, ref this._X2, value); }
		}
		private double _Y2;
		public double Y2
		{
			get { return this._Y2; }
			set { Set(() => this.Y2, ref this._Y2, value); }
		}
	}
