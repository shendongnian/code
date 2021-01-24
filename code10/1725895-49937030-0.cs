	public class Node
	{
		public string Key { get; set; }
		public Node Parent { get; set; }
		public IList<Node> Children { get; set; }
	}
	private Node LoadAll(string[] keys)
	{
		var nodes = new Dictionary<string, Node>(StringComparer.OrdinalIgnoreCase);
		var orphanNodes = new List<Node>();
		Node root = null;
		foreach (var key in keys)
		{
			var node = new Node()
			{
				Key = key
			};
			nodes[key] = node;
			int keySeparator = key.LastIndexOf("-");
			if (keySeparator != -1)
			{
				string parentKey = key.Substring(0, keySeparator);
				if (nodes.TryGetValue(parentKey, out var parentNode))
				{
					if (parentNode.Children == null)
					{
						parentNode.Children = new List<Node>();
					}
					node.Parent = parentNode;
					parentNode.Children.Add(node);
				}
				else
				{
					orphanNodes.Add(node);
				}
			}
			else if (root != null)
			{
				throw new Exception("Root node already exists.");
			}
			else
			{
				root = node;
			}
		}
		foreach (var orphan in orphanNodes)
		{
			string parentKey = orphan.Key.Substring(0, orphan.Key.LastIndexOf("-"));
			if (nodes.TryGetValue(parentKey, out var parentNode))
			{
				if (parentNode.Children == null)
				{
					parentNode.Children = new List<Node>();
				}
				orphan.Parent = parentNode;
				parentNode.Children.Add(orphan);
			}
			else
			{
				throw new Exception("Nodes without parents found.");
			}
		}
		return root;
	}
