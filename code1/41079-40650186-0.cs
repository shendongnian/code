        public static bool ValueEquals(Array array1, Array array2)
		{
			if( array1 == null && array2 == null )
			{
				return true;
			}
			if( (array1 == null) || (array2 == null) )
			{
				return false;
			}
			if( array1.Length != array2.Length )
			{
				return false;
			}
            if( array1.Equals(array2))
            {
               return true;
            }
			else
			{
				for (int Index = 0; Index < array1.Length; Index++)
				{
					if( !Equals(array1.GetValue(Index), array2.GetValue(Index)) )
					{
						return false;
					}
				}
			}
			return true;
		}
