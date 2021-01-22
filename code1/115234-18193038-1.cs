	using System.Collections.Generic;
	namespace ConsoleApplication1
	{
		public class Permutation
		{
			public IEnumerable<T[]> GetPermutations<T>(T[] items)
			{
				var work = new int[items.Length];
				for (var i = 0; i < work.Length; i++)
				{
					work[i] = i;
				}
				foreach (var index in GetIntPermutations(work, 0, work.Length))
				{
					var result = new T[index.Length];
					for (var i = 0; i < index.Length; i++) result[i] = items[index[i]];
					yield return result;
				}
			}
			public IEnumerable<int[]> GetIntPermutations(int[] index, int offset, int len)
			{
				switch (len)
				{
					case 1:
						yield return index;
						break;
					case 2:
						yield return index;
						Swap(index, offset, offset + 1);
						yield return index;
						Swap(index, offset, offset + 1);
						break;
					default:
						foreach (var result in GetIntPermutations(index, offset + 1, len - 1))
						{
							yield return result;
						}
						for (var i = 1; i < len; i++)
						{
							Swap(index, offset, offset + i);
							foreach (var result in GetIntPermutations(index, offset + 1, len - 1))
							{
								yield return result;
							}
							Swap(index, offset, offset + i);
						}
						break;
				}
			}
			private static void Swap(IList<int> index, int offset1, int offset2)
			{
				var temp = index[offset1];
				index[offset1] = index[offset2];
				index[offset2] = temp;
			}
		}
	}
