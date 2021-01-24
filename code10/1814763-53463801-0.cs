	namespace Project1
	{
		using System.Collections.Generic;
		using System.Threading.Tasks;
		internal class Program
		{
			private static int j = 0;
			private readonly List<Queue<string>> queueList = new List<Queue<string>>();
			public void StartTasts(int n)
			{
				for (var i = 0; i < n; i++)
				{
					this.queueList.Add(new Queue<string>());
				}
				var taskList = new List<Task>();
				for (var taskGroup = 0; taskGroup < 10; taskGroup++)
				{
					// 10 groups of task
					// each group has 'n' tasks working in parallel
					for (var i = 0; i < n; i++)
					{
						// each task gets its own and independent queue from the list
						var taskId = j % n;
						taskList.Add(
							Task.Factory.StartNew(
								() =>
								{
									this.DoWork(taskId);
								}));
						j++;
					}
					// waiting for each task group to finish
					foreach (var t in taskList)
					{
						t.Wait();
					}
					// after they all finished working with the queues, clear queues
					// making them ready for the nest task group
					foreach (var q in this.queueList)
					{
						q.Clear();
					}
				}
			}
			public void DoWork(int queue)
			{
				// demonstration of generating strings 
				// and put them in the correct queue
				for (var k = 0; k < 10000; k++)
				{
					this.queueList[queue].Enqueue(k + string.Empty);
				}
			}
			private static void Main(string[] args)
			{
				new Program().StartTasts(10);
			}      
		}
	}
