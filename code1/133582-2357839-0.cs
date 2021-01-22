    public struct Distance : IEquatable<Distance>, IComparable<Distance>
    {
        private static readonly double MetersPerKilometer = 1000.0;
        private static readonly double CentimetersPerMeter = 100.0;
        private static readonly double CentimetersPerInch = 2.54;
        private static readonly double InchesPerFoot = 12.0;
        private static readonly double FeetPerYard = 3.0;
        private static readonly double FeetPerMeter = CentimetersPerMeter / (CentimetersPerInch * InchesPerFoot);
        private static readonly double InchesPerMeter = CentimetersPerMeter / CentimetersPerInch;
        private readonly double _meters;
        public Distance(double meters)
        {
            this._meters = meters;
        }
        public double TotalKilometers
        {
            get
            {
                return _meters / MetersPerKilometer;
            }
        }
        public double TotalMeters
        {
            get
            {
                return _meters;
            }
        }
        public double TotalCentimeters
        {
            get
            {
                return _meters * CentimetersPerMeter;
            }
        }
        public double TotalYards
        {
            get
            {
                return _meters * FeetPerMeter / FeetPerYard;
            }
        }
        public double TotalFeet
        {
            get
            {
                return _meters * FeetPerMeter;
            }
        }
        public double TotalInches
        {
            get
            {
                return _meters * InchesPerMeter;
            }
        }
        public static Distance FromKilometers(double value)
        {
            return new Distance(value * MetersPerKilometer);
        }
        public static Distance FromMeters(double value)
        {
            return new Distance(value);
        }
        public static Distance FromCentimeters(double value)
        {
            return new Distance(value / CentimetersPerMeter);
        }
        public static Distance FromYards(double value)
        {
            return new Distance(value * FeetPerYard / FeetPerMeter);
        }
        public static Distance FromFeet(double value)
        {
            return new Distance(value / FeetPerMeter);
        }
        public static Distance FromInches(double value)
        {
            return new Distance(value / InchesPerMeter);
        }
        public static Distance operator +(Distance a, Distance b)
        {
            return new Distance(a._meters + b._meters);
        }
        public static Distance operator -(Distance a, Distance b)
        {
            return new Distance(a._meters - b._meters);
        }
        public static Distance operator -(Distance a)
        {
            return new Distance(-a._meters);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Distance))
                return false;
            return Equals((Distance)obj);
        }
        public bool Equals(Distance other)
        {
            return this._meters == other._meters;
        }
        public int CompareTo(Distance other)
        {
            return this._meters.CompareTo(other._meters);
        }
        public override int GetHashCode()
        {
            return _meters.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0}[m]", TotalMeters);
        }
    }
