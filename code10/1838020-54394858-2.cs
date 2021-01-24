	private IEnumerable<PeNet.Asn1.Asn1Node> FlattenNodes(Asn1Node parentNode)
	{
		yield return parentNode;
		foreach (var childNode in parentNode.Nodes)
		{
			foreach (var grandchildNode in FlattenNodes(childNode))
			{
				yield return grandchildNode;
			}
		}
	}
