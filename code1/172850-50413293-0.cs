        public static double Sin(double d) {
            d = d % (2 * Math.PI); // Math.Sin calculates wrong results for values larger than 1e6
            if (d == 0 || d == Math.PI || d == -Math.PI) {
                return 0.0;
            }
            else {
                return Math.Sin(d);
            }
        }
        public static double Cos(double d) {
            d = d % (2 * Math.PI); // Math.Cos calculates wrong results for values larger than 1e6
            double multipleOfPi = d / Math.PI; // avoid calling the expensive modulo function twice
            if (multipleOfPi == 0.5 || multipleOfPi == -0.5 || multipleOfPi == 1.5 || multipleOfPi == -1.5) { 
                return 0.0;
            }
            else {
				return Math.Cos(d);
			}
		}
