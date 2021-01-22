    public static IEnumerable<T> GetRandom<T>(this IList<T> list, int count, Random random)
		{
			// Probably you should throw exception if count > list.Count
			count = Math.Min(list.Count, count);
			var selectedIndices = new SortedSet<int>();
			// Random upper bound
			int randomMax = list.Count - 1;
			while (selectedIndices.Count < count)
			{
				int randomIndex = random.Next(0, randomMax);
				// skip over already selected indeces
				foreach (var selectedIndex in selectedIndices)
					if (selectedIndex <= randomIndex)
						++randomIndex;
					else
						break;
				yield return list[randomIndex];
				selectedIndices.Add(randomIndex);
				--randomMax;
			}
		}
