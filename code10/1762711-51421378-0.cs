		public enum RowCol {row, col}
		public Vector this[RowCol set, int rowcol]
		{
			get
			{
				switch (set)
				{
					case RowCol.col:
						return Transpose().m[rowcol];
					default:
						return m[rowcol];
				}
			}
			set
			{
				switch (set)
				{
					case RowCol.col:
						Matrix temp = Transpose();
						temp[RowCol.row, rowcol] = value;
						temp = temp.Transpose();
						m = temp.m;
						break;
					default:
						m[rowcol] = value;
						break;
				}
			}
		}
