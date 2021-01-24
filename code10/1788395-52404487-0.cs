    int[][] arrays = new int[][]
			{
				new []{1,4,4,6,6,3},
				new []{4,8,6,5,7,3},
				new []{6,6,9,3,3,9}
			};
			var list = new List<int>();
			foreach (var array in arrays)
				list.AddRange(array);
			var result = list.GroupBy(i => i)
				.Select(g => new { Value = g.Key, Count = g.Count() })
				.Where(x => x.Count > 1);
