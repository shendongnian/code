		private static Random rnd = new Random((int)DateTime.Now.Ticks);
		private static Int32 SetRandomTrueBitToFalse(Int32 p)
		{
			List<int> trueBits = new List<int>();
			for (int i = 0; i < 31; i++)
			{
				if ((p>>i&1) == 1){
					trueBits.Add(i);
				}
			}
			if (trueBits.Count>0){
				int index = rnd.Next(0, trueBits.Count);
				return p & ~(1 << trueBits[index]);
			}
			return p;
		}
