    class ListComparer : IComparer
	{
		private ComparerState State = ComparerState.Init;
		public string Field {get;set;}
                
		
		public int Compare(object x, object y) 
		{
			object cx;
			object cy;
			if (State == ComparerState.Init) 
			{
				if (x.GetType().GetProperty(pField) == null)
					State = ComparerState.Field;
				else
					State = ComparerState.Property;
			}
			if (State == ComparerState.Property) 
			{
				cx = x.GetType().GetProperty(Field).GetValue(x,null);
				cy = y.GetType().GetProperty(Field).GetValue(y,null);
			}
			else 
			{
				cx = x.GetType().GetField(Field).GetValue(x);
				cy = y.GetType().GetField(Field).GetValue(y);
			}
			
			if (cx == null) 
				if (cy == null)
					return 0;
				else 
					return -1;
			else if (cy == null)
				return 1;
			return ((IComparable) cx).CompareTo((IComparable) cy);
		}
		private enum ComparerState 
		{
			Init,
			Field,
			Property
		}
	}
