        public bool IsPrime(int val)
		{
			Collection<int> PrimeNumbers = new Collection<int>();
			int CheckNumber = 5;
			bool divisible = true;
			PrimeNumbers.Add(2);
			PrimeNumbers.Add(3);
			// Populating the Prime Number Collection
			while (CheckNumber < val)
			{
				foreach (int i in PrimeNumbers)
				{
					if (CheckNumber % i == 0)
					{
						divisible = false;
						break;
					}
					if (i * i > CheckNumber) { break; }
				}
				if (divisible == true) { PrimeNumbers.Add(CheckNumber); }
				else { divisible = true; }
				CheckNumber += 2;
			}
			foreach (int i in PrimeNumbers)
			{
				if (CheckNumber % i == 0)
				{
					divisible = false;
					break;
				}
				if (i * i > CheckNumber) { break; }
			}
			if (divisible == true) { PrimeNumbers.Add(CheckNumber); }
			else { divisible = true; }
			// Use the Prime Number Collection to determine if val is prime
			foreach (int i in PrimeNumbers)
			{
				if (val % i == 0) { return false; }
				if (i * i > val) { return true; }
			}
			// Shouldn't ever get here, but needed to build properly.
			return true;
		}
