    public static List<T> ReorderListIntoColumns<T>(List<T> list, int totalColumns)
		{
			List<T> reordered = new List<T>();
			int itemsPerColumn = (int) list.Count / totalColumns;
			for (int i = 0; i < itemsPerColumn; i++)
			{
				for (int j = 0; j < totalColumns; j++)
				{
					reordered.Add(list[(j * itemsPerColumn) + i]);
				}
			}
			return reordered;
		}
