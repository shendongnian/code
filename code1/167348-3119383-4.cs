	public class Distance {
		private double _distanceValue;
		private UnitOfMeasure _uom;
		
		public double DistanceValue {
			get { return _distanceValue; }
			set { _distanceValue = value; }
		}
		
			public UnitOfMeasure Uom {
			get { return _uom; }
			set { _uom = value; }
		}
	}
	
	public enum UnitOfMeasure {
		Kilometers,
		Miles,
		Feet,
		Inches,
		Parsecs
	}
