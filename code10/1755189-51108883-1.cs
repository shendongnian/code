	public class Child : Parent
	{
		[ThreadStatic]
		private static Random _random;
		public override float ageInYears
		{
			 get
			 {
				if (_random == null)
				{
					var cryptoResult = new byte[4];
					new RNGCryptoServiceProvider().GetBytes(cryptoResult);
					int seed = BitConverter.ToInt32(cryptoResult, 0);
					_random = new Random(seed);
				}
				return (float)_random.Next(0, 10);
			 }
		}
	}
