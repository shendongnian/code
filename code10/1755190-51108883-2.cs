	public class Child : Parent
	{
		[ThreadStatic]
		private static Random _random;
		
		private float _ageInYears;
		public override float ageInYears { get { return _ageInYears; } }
		
		public Child()
		{
			if (_random == null)
			{
				var cryptoResult = new byte[4];
				new RNGCryptoServiceProvider().GetBytes(cryptoResult);
				
				int seed = BitConverter.ToInt32(cryptoResult, 0);
				
				_random = new Random(seed);
			}
			_ageInYears = (float)_random.Next(0, 10);
		}
	}
