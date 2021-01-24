    class MyDbTableComparer : IEqualityComparer<MyDbTable>
	{
		public bool Equals(MyDbTable x, MyDbTable y)
		{
			if (x.Col1 == y.Col2 && x.Col2 == y.Col1) return true;
			return false;
		}
	}
