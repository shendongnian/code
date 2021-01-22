	class Program
	{
		static void Main(string[] args)
		{
			IList&lt;DateTime&gt; l1, l2;
			DateTime begin = new DateTime(2000, 1, 1);
			Stopwatch timer1 = Stopwatch.StartNew();
			for (int i = 0; i &lt; 10000; i++)
				l1 = GetDates(begin);
			timer1.Stop();
			Stopwatch timer2 = Stopwatch.StartNew();
			for (int i = 0; i &lt; 10000; i++)
				l2 = GetDates2(begin);
			timer2.Stop();
			Console.WriteLine("new DateTime: {0}\n.AddDays: {1}",
				timer1.ElapsedTicks, timer2.ElapsedTicks);
			Console.ReadLine();
		}
		static IList&lt;DateTime&gt; GetDates(DateTime StartDay)
		{
			IList&lt;DateTime&gt; dates = new List&lt;DateTime&gt;();
			int TotalDays = DateTime.DaysInMonth(StartDay.Year, StartDay.Month);
			for (int i = 0; i &lt; TotalDays; i++)
				dates.Add(new DateTime(StartDay.Year, StartDay.Month, i + 1));
			return dates;
		}
		static IList&lt;DateTime&gt; GetDates2(DateTime StartDay)
		{
			IList&lt;DateTime&gt; dates = new List&lt;DateTime&gt;();
			DateTime NextMonth = StartDay.AddMonths(1);
			for (DateTime curr = StartDay; !curr.Equals(NextMonth); curr = curr.AddDays(1))
				dates.Add(curr);
			return dates;
		}
	} // class</code></pre>
Output (I added the commas):
new DateTime: 545,307,375
.AddDays: 180,071,512
