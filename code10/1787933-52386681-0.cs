    public class Coordinate {
		
        // Hidden parameterless ctor
		private Coordinate() {}
		
        // Public ctor requires two numbers
		public Coordinate(decimal x, decimal y) : this() {
			X = x;
			Y = y;
		}
		
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
		
		public const char AxisSeparator = ',';
        public bool IsValid() {
            return X.HasValue && Y.HasValue;
        }
        // Try to parse a coordinate text in the format "X.XX{AxisSeparator}Y.YY"
        // If the parsing is not successful, returns false and error message as out variable
        // Else returns true and the parsed Coordinate as out variable
        public static bool TryParse(string input, out Coordinate result, out string errorMessage) {
			errorMessage = string.Empty;
			result = new Coordinate();
			
            var parts = input.Split(AxisSeparator);
			if (parts.Count() != 2) {
			 	errorMessage = "Expected input in format 'X.XX, Y.YY' with '" + AxisSeparator + "' to separate X and Y coordinates.";
				return false;
			}
			
			decimal x;
			decimal y;
			if (!decimal.TryParse(parts[0], out x)) {
				errorMessage = "Expected input in format 'X.XX, Y.YY' with X.XX as number, but it was '" + parts[0] + "'.";
				return false;
			}
				
			if (!decimal.TryParse(parts[1], out y)) {
				errorMessage = "Expected input in format 'X.XX, Y.YY' with Y.YY as number, but it was '" + parts[1] + "'.";
				return false;
			}
				
			result = new Coordinate(x, y);
	        return true;
        }
		
		public override string ToString() { return X.ToString() + AxisSeparator + " " + Y.ToString(); }
    }
