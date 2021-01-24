    	public int Solver(int coinsRemaining, int coinsOnNextRow)
		{
			if (coinsRemaining >= coinsOnNextRow)
			{
				return Solver(coinsRemaining - coinsOnNextRow, coinsOnNextRow + 1);
			}
			return coinsOnNextRow - 1;
		}
		public int ArrangeCoins(int n)
		{
			return Solver(n, 1);
		}
