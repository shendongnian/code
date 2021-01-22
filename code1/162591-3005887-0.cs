	class Complex
	{
		public override bool Equals(object obj)
		{
			if (obj is Complex)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
