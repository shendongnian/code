	// A delegate makes life simpler
	delegate void MainDelegate(Anything sender, bool original);
	class Program {
		private const int COUNT = 15;
		private static List<Anything> m_list;
		static void Main(string[] args) {
			m_list = new List<Anything>(COUNT);
			var obj = new AnyTask();
			obj.OnUpdate += new MainDelegate(ThreadMessages);
			obj.Test_Function(COUNT);
			Console.WriteLine();
			foreach (var item in m_list) {
				Console.WriteLine("[Complete]:" + item.Text);
			}
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}
		private static void ThreadMessages(Anything item, bool original) {
			if (original) {
				Console.WriteLine("[main method]:" + item.Text);
			} else {
				m_list.Add(item);
			}
		}
	}
