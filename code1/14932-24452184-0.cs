	static public int GetRank( this XmlNode node )
	{
		// return 0 if unique, else return position 1...n in siblings with same name
		try
		{
			if( node is XmlElement ) 
			{
				int rank = 1;
				bool alone = true, found = false;
				foreach( XmlNode n in node.ParentNode.ChildNodes )
					if( n.Name == node.Name ) // sibling with same name
					{
						if( n.Equals(node) )
						{
							if( ! alone ) return rank; // no need to continue
							found = true;
						}
						else
						{
							if( found ) return rank; // no need to continue
							alone = false;
							rank++;
						}
					}
					
			}
		}
		catch{}
		return 0;
	}
	static public string GetXPath( this XmlNode node )
	{
		try
		{
			if( node is XmlAttribute )
				return String.Format( "{0}/@{1}", (node as XmlAttribute).OwnerElement.GetXPath(), node.Name );
			if( node is XmlText || node is XmlCDataSection )
				return node.ParentNode.GetXPath();
			if( node.ParentNode == null )	// the only node with no parent is the root node, which has no path
				return "";
			int rank = node.GetRank();
			if( rank == 0 )	return String.Format( "{0}/{1}",		node.ParentNode.GetXPath(), node.Name );
			else			return String.Format( "{0}/{1}[{2}]",	node.ParentNode.GetXPath(), node.Name, rank );
		}
		catch{}
		return "";
	}	
