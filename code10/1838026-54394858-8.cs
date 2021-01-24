	private IEnumerable<Asn1Node> FlattenNodes(Asn1Node parentNode)
	{
		yield return parentNode;
		foreach (var childNode in parentNode.Nodes)
		{
			foreach (var grandChildNode in FlattenNodes(childNode))
			{
				yield return grandChildNode;
			}
		}
	}
