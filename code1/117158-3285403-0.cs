    	public static long NextLong(this Random rnd, long min, long max) {
			if (max <= min)
				throw new Exception("Min must be less than max.");
			long dif = max - min;
			var bytes = new byte[8];
			rnd.NextBytes(bytes);
			bytes[7] &= 0x7f; //strip sign bit
			long posNum = BitConverter.ToInt64(bytes, 0);
			while (posNum > dif)
				posNum >>= 1;
			return min + posNum;
		}
