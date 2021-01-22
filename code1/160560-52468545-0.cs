        public static string toBinary(int base10)
		{
			string binary = "";
			do {
				binary = (base10 % 2) + binary;
				base10 /= 2;
			}
			while (base10 > 0);
			
			return binary;
		}
