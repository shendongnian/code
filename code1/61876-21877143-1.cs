	namespace MoeCard.TestConsole
	{
		class Program
		{
			static void Main(string[] args)
			{
				Program p = new Program() { AAA = Guid.NewGuid().ToString(), BBB = 123 };
				Stopwatch sw = Stopwatch.StartNew();
				for (int i = 0; i < 10000; i++)
				{
					p.Copy1();
				}
				sw.Stop();
				Console.WriteLine("Manual Copy:" + sw.Elapsed);
				sw.Restart();
				for (int i = 0; i < 10000; i++)
				{
					p.Copy2();
				}
				sw.Stop();
				Console.WriteLine("MemberwiseClone:" + sw.Elapsed);
				Console.ReadLine();
			}
			public string AAA;
			public int BBB;
			public Class1 CCC = new Class1();
			public Program Copy1()
			{
				return new Program() { AAA = AAA, BBB = BBB, CCC = CCC };
			}
			public Program Copy2()
			{
				return this.MemberwiseClone() as Program;
			}
			public class Class1
			{
				public DateTime Date = DateTime.Now;
			}
		}
	}
