	class Program
	{
		static void Main(string[] args)
		{
			int[, ,] theArray = new int[2, 8, 12];
			theArray[0, 0, 1] = 99;
			theArray[0, 1, 0] = 199;
			theArray[1, 0, 0] = 299;
			Walker w = new Walker(theArray);
			foreach (int i in w)
			{
				Console.WriteLine("Item[{0},{1},{2}] = {3}", w.Pos[0], w.Pos[1], w.Pos[2], i);
			}
			Console.ReadKey();
		}
		public class Walker : IEnumerable<int>
		{
			public Array Data { get; private set; }
			public int[] Pos { get; private set; }
			public Walker(Array array)
			{
				this.Data = array;
				this.Pos = new int[array.Rank];
			}
			public IEnumerator<int> GetEnumerator()
			{
				return this.RecurseRank(0);
			}
			private IEnumerator<int> RecurseRank(int rank)
			{
				for (int i = this.Data.GetLowerBound(rank); i <= this.Data.GetUpperBound(rank); ++i)
				{
					this.Pos.SetValue(i, rank);
					if (rank < this.Pos.Length - 1)
					{
						IEnumerator<int> e = this.RecurseRank(rank + 1);
						while (e.MoveNext())
						{
							yield return e.Current;
						}
					}
					else
					{
						yield return (int)this.Data.GetValue(this.Pos);
					}
				}
			}
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return this.RecurseRank(0);
			}
		}
	}
