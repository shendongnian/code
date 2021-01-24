    using System;
	using System.Collections.Generic;
	using System.Linq;
	public class Hierarchy
	{
		public Hierarchy(string iD, string name, int level, string parentID, string topParent)
		{
			ID = iD;
			Name = name;
			Level = level;
			ParentID = parentID;
			Children = new HashSet<Hierarchy>();
		}
		public string ID { get; set; }
		public string Name{ get; set; }
		public int Level { get; set; }
		public string ParentID { get; set; }
		public ICollection<Hierarchy> Children { get; set; }
	}
	public class Program
	{
		static Hierarchy CreateTree(IEnumerable<Hierarchy> Nodes)
		{
			var idToNode = Nodes.ToDictionary(n => n.ID, n => n);
			Hierarchy root = null;
			foreach (var n in Nodes)
			{
				if (n.ParentID == null)
				{
					if (root != null)
					{
						//there are multiple roots in the data
					}
					root = n;
					continue;
				}
				Hierarchy parent = null;
				if (!idToNode.TryGetValue(n.ParentID, out parent))
				{
					//Parent doesn't exist, orphaned entry
				}
				parent.Children.Add(n);
				Console.WriteLine("ReferenceEquals: {0}", Object.ReferenceEquals(parent, root));
			}
			if (root == null)
			{
				//There was no root element
			}
			return root;
		}
		public static void Main()
		{
			Console.WriteLine("Test #1");
			List<Hierarchy>	l = new List<Hierarchy>();
			l.Add(new Hierarchy("295152","name1",1,null, null)); // <-root node at the top of the list
			l.Add(new Hierarchy("12345","child1",2,"295152", null));
			l.Add(new Hierarchy("54321","child2",2,"295152", null));
			l.Add(new Hierarchy("44444","child1a",3,"12345", null));
			l.Add(new Hierarchy("33333","child1b",3,"12345", null));
			l.Add(new Hierarchy("22222","child2a",3,"54321", null));
			l.Add(new Hierarchy("22221","child2b",3,"54321", null));
			l.Add(new Hierarchy("22002","child2c",3,"54321", null));
			l.Add(new Hierarchy("20001","child2a2",4,"22222", null));
			l.Add(new Hierarchy("20101","child2b2",4,"22222", null));		
			CreateTree(l);
			Console.WriteLine("\nTest #2");
			l = new List<Hierarchy>();
			l.Add(new Hierarchy("12345","child1",2,"295152", null));
			l.Add(new Hierarchy("54321","child2",2,"295152", null));
			l.Add(new Hierarchy("44444","child1a",3,"12345", null));
			l.Add(new Hierarchy("33333","child1b",3,"12345", null));
			l.Add(new Hierarchy("22222","child2a",3,"54321", null));
			l.Add(new Hierarchy("22221","child2b",3,"54321", null));
			l.Add(new Hierarchy("22002","child2c",3,"54321", null));
			l.Add(new Hierarchy("20001","child2a2",4,"22222", null));
			l.Add(new Hierarchy("20101","child2b2",4,"22222", null));
			l.Add(new Hierarchy("295152","name1",1,null, null)); // <-root node at the bottom of the list
			CreateTree(l);
		}
	}
