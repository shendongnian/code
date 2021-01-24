    var xml = 
		XElement.Parse(@"<parent>
		<child>
			<key> one </key>
			<key> two </key>
			<key> Three </key>
		</child>
		<child>
			<key> one </key>
			<key> two </key>
			<key> Three </key>
		</child>
		</parent>");
		
	var elementsAndIndex =
		xml
		.DescendantsAndSelf()
		.Select((node, index) => new { index = index + 1, node })
		.ToList();
		
	List<XmlModel> elementsWithIndexAndParentIndex =
		elementsAndIndex
		.Select(
			elementAndIndex =>
				new
				{
					Element = elementAndIndex.node,
					Index = elementAndIndex.index,
					ParentElement = elementsAndIndex.SingleOrDefault(parent => parent.node == elementAndIndex.node.Parent)
				})
		.Select(
			elementAndIndexAndParent =>
				new XmlModel
				{
					NodeName = elementAndIndexAndParent.Element.Name.LocalName,
					NodeId = elementAndIndexAndParent.Index,
					ParentId = elementAndIndexAndParent.ParentElement == null ? 0 : elementAndIndexAndParent.ParentElement.index
				})
		.ToList();
