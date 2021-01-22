    [StructLayout(LayoutKind.Sequential), ComVisible(true)]
    	public struct Distance : IEquatable<Distance>, IComparable<Distance>
    	{
    		private const double MetersPerKilometer = 1000.0;
    		private const double CentimetersPerMeter = 100.0;
    		private const double CentimetersPerInch = 2.54;
    		private const double InchesPerFoot = 12.0;
    		private const double FeetPerYard = 3.0;
    		private const double FeetPerMile = 5280.0;
    		private const double FeetPerMeter = CentimetersPerMeter / (CentimetersPerInch * InchesPerFoot);
    		private const double InchesPerMeter = CentimetersPerMeter / CentimetersPerInch;
    
    		public static readonly Distance Zero = new Distance(0.0);
    
    		private readonly double meters;
    
    		/// <summary>
    		/// Initializes a new Distance to the specified number of meters.
    		/// </summary>
    		/// <param name="meters"></param>
    		public Distance(double meters)
    		{
    			this.meters = meters;
    		}
    
    		/// <summary>
    		/// Gets the value of the current Distance structure expressed in whole and fractional kilometers. 
    		/// </summary>
    		public double TotalKilometers
    		{
    			get
    			{
    				return meters / MetersPerKilometer;
    			}
    		}
    
    		/// <summary>
    		/// Gets the value of the current Distance structure expressed in whole and fractional meters. 
    		/// </summary>
    		public double TotalMeters
    		{
    			get
    			{
    				return meters;
    			}
    		}
    
    		/// <summary>
    		/// Gets the value of the current Distance structure expressed in whole and fractional centimeters. 
    		/// </summary>
    		public double TotalCentimeters
    		{
    			get
    			{
    				return meters * CentimetersPerMeter;
    			}
    		}
    
    		/// <summary>
    		/// Gets the value of the current Distance structure expressed in whole and fractional yards. 
    		/// </summary>
    		public double TotalYards
    		{
    			get
    			{
    				return meters * FeetPerMeter / FeetPerYard;
    			}
    		}
    
    		/// <summary>
    		/// Gets the value of the current Distance structure expressed in whole and fractional feet. 
    		/// </summary>
    		public double TotalFeet
    		{
    			get
    			{
    				return meters * FeetPerMeter;
    			}
    		}
    
    		/// <summary>
    		/// Gets the value of the current Distance structure expressed in whole and fractional inches. 
    		/// </summary>
    		public double TotalInches
    		{
    			get
    			{
    				return meters * InchesPerMeter;
    			}
    		}
    
    		/// <summary>
    		/// Gets the value of the current Distance structure expressed in whole and fractional miles. 
    		/// </summary>
    		public double TotalMiles
    		{
    			get
    			{
    				return meters * FeetPerMeter / FeetPerMile;
    			}
    		}
    
    		/// <summary>
    		/// Returns a Distance that represents a specified number of kilometers.
    		/// </summary>
    		/// <param name="value">A number of kilometers.</param>
    		/// <returns></returns>
    		public static Distance FromKilometers(double value)
    		{
    			return new Distance(value * MetersPerKilometer);
    		}
    
    		/// <summary>
    		/// Returns a Distance that represents a specified number of meters.
    		/// </summary>
    		/// <param name="value">A number of meters.</param>
    		/// <returns></returns>
    		public static Distance FromMeters(double value)
    		{
    			return new Distance(value);
    		}
    
    		/// <summary>
    		/// Returns a Distance that represents a specified number of centimeters.
    		/// </summary>
    		/// <param name="value">A number of centimeters.</param>
    		/// <returns></returns>
    		public static Distance FromCentimeters(double value)
    		{
    			return new Distance(value / CentimetersPerMeter);
    		}
    
    		/// <summary>
    		/// Returns a Distance that represents a specified number of yards.
    		/// </summary>
    		/// <param name="value">A number of yards.</param>
    		/// <returns></returns>
    		public static Distance FromYards(double value)
    		{
    			return new Distance(value * FeetPerYard / FeetPerMeter);
    		}
    
    		/// <summary>
    		/// Returns a Distance that represents a specified number of feet.
    		/// </summary>
    		/// <param name="value">A number of feet.</param>
    		/// <returns></returns>
    		public static Distance FromFeet(double value)
    		{
    			return new Distance(value / FeetPerMeter);
    		}
    
    		/// <summary>
    		/// Returns a Distance that represents a specified number of inches.
    		/// </summary>
    		/// <param name="value">A number of inches.</param>
    		/// <returns></returns>
    		public static Distance FromInches(double value)
    		{
    			return new Distance(value / InchesPerMeter);
    		}
    
    		/// <summary>
    		/// Returns a Distance that represents a specified number of miles.
    		/// </summary>
    		/// <param name="value">A number of miles.</param>
    		/// <returns></returns>
    		public static Distance FromMiles(double value)
    		{
    			return new Distance(value * FeetPerMile / FeetPerMeter);
    		}
    
    		public static bool operator ==(Distance a, Distance b)
    		{
    			return (a.meters == b.meters);
    		}
    
    		public static bool operator !=(Distance a, Distance b)
    		{
    			return (a.meters != b.meters);
    		}
    
    		public static bool operator >(Distance a, Distance b)
    		{
    			return (a.meters > b.meters);
    		}
    
    		public static bool operator >=(Distance a, Distance b)
    		{
    			return (a.meters >= b.meters);
    		}
    
    		public static bool operator <(Distance a, Distance b)
    		{
    			return (a.meters < b.meters);
    		}
    
    		public static bool operator <=(Distance a, Distance b)
    		{
    			return (a.meters <= b.meters);
    		}
    
    		public static Distance operator +(Distance a, Distance b)
    		{
    			return new Distance(a.meters + b.meters);
    		}
    
    		public static Distance operator -(Distance a, Distance b)
    		{
    			return new Distance(a.meters - b.meters);
    		}
    
    		public static Distance operator -(Distance a)
    		{
    			return new Distance(-a.meters);
    		}
    
    		public override bool Equals(object obj)
    		{
    			if (!(obj is Distance))
    				return false;
    
    			return Equals((Distance)obj);
    		}
    
    		public bool Equals(Distance value)
    		{
    			return this.meters == value.meters;
    		}
    
    		public int CompareTo(Distance value)
    		{
    			return this.meters.CompareTo(value.meters);
    		}
    
    		public override int GetHashCode()
    		{
    			return meters.GetHashCode();
    		}
    
    		public override string ToString()
    		{
    			return string.Format("{0} meters", TotalMeters);
    		}
    	}
