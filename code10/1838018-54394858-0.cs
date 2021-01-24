	var node = PeNet.Asn1.Asn1Node.ReadNode(cert.RawData);
	urls =
		FlattenNodes(node)
		.Where(n => n.Nodes.Count > 0 && n.Nodes[0] is Asn1ObjectIdentifier && ((Asn1ObjectIdentifier)n.Nodes[0]).FriendlyName == "subjectAltName")
		.SelectMany(n => n.Nodes).OfType<Asn1OctetString>()
		.SelectMany(o => Asn1Sequence.ReadNode(o.Data).Nodes).OfType<Asn1CustomNode>()
		.Select(o => System.Text.Encoding.UTF8.GetString(o.Data))
		.ToArray();
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
