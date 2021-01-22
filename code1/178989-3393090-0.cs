	class Program
	{
		private class Toy
		{
			public string Name { get; set; }
			public int Time { get; set; }
		}
		private class Node : IEquatable<Node>
		{
			public Node()
			{
				Start = new List<Toy>();
				End = new List<Toy>();
			}
			public Node Clone()
			{
				return new Node
				{
					Start = new List<Toy>(Start),
					End = new List<Toy>(End),
					Time = Time,
					Previous = this
				};
			}
			public int Time { get; set; }
			public List<Toy> Start { get; set; }
			public List<Toy> End { get; set; }
			public Node Previous { get; set; }
			public Toy Go1 { get; set; }
			public Toy Go2 { get; set; }
			public Toy Return { get; set; }
			public bool Equals(Node other)
			{
				return Start.TrueForAll(t => other.Start.Contains(t)) &&
					   End.TrueForAll(t => other.End.Contains(t)) &&
					   Time == other.Time;
			}
		}
		private static void GenerateNodes(Node node, Queue<Node> open, List<Node> closed)
		{
			foreach(var toy1 in node.Start)
			{
				foreach(var toy2 in node.Start.Where(t => t != toy1))
				{
					var newNode = node.Clone();
					newNode.Start.Remove(toy1);
					newNode.Start.Remove(toy2);
					newNode.End.Add(toy1);
					newNode.End.Add(toy2);
					newNode.Go1 = toy1;
					newNode.Go2 = toy2;
					newNode.Time += Math.Max(toy1.Time, toy2.Time);
					if(newNode.Time <= 60 && !closed.Contains(newNode) && !open.Contains(newNode))
					{
						open.Enqueue(newNode);
					}
				}
			}
		}
		static void Main(string[] args)
		{
			var open = new Queue<Node>();
			var closed = new List<Node>();
			var initial = new Node
			              	{
			              		Start = new List<Toy>
			              		        	{
			              		        		new Toy {Name = "Buzz", Time = 5},
			              		        		new Toy {Name = "Woody", Time = 10},
			              		        		new Toy {Name = "Rex", Time = 20},
			              		        		new Toy {Name = "Ham", Time = 25}
			              		        	}
			              	};
			open.Enqueue(initial);
			var resultNodes = new List<Node>();
			while(open.Count != 0)
			{
				var current = open.Dequeue();
				closed.Add(current);
				if(current.End.Count == 4)
				{
					resultNodes.Add(current);
					continue;
				}
				if(current.End.Count != 0)
				{
					var fastest = current.End.OrderBy(t => t.Time).First();
					current.End.Remove(fastest);
					current.Start.Add(fastest);
					current.Time += fastest.Time;
					current.Return = fastest;
				}
				GenerateNodes(current, open, closed);
			}
			foreach(var result in resultNodes)
			{
				var path = new List<Node>();
				var node = result;
				while(true)
				{
					if(node.Previous == null) break;
					path.Insert(0, node);
					node = node.Previous;
				}
				path.ForEach(n => Console.WriteLine("Went: {0} {1}, Came back: {2}, Time: {3}", n.Go1.Name, n.Go2.Name, n.Return != null ? n.Return.Name : "nobody", n.Time));
				Console.WriteLine(Environment.NewLine);
			}
			Console.ReadLine();
		}
	}
