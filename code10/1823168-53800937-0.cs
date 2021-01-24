	internal class YTest
	{
		[IteratorStateMachine(typeof(YTest.<TestYield>d__0))]
		public static IEnumerable<int> TestYield(bool check)
		{
			int num;
			while (num == 0)
			{
				if (!check)
				{
					Console.WriteLine("In the else");
					IL_52:
					yield break;
				}
				yield return 1;
			}
			if (num != 1)
			{
				yield break;
			}
			goto IL_52;
		}
	}
