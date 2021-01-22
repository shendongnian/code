    // ...in your class derived from 'XamlXmlReader'
	public void transform(my_xaml_obj_writer xow)
	{
		while (base.Read())
		{
			if (xow.ShouldProvideLineInfo)
				xow.SetLineInfo(LineNumber, LinePosition);
			switch (NodeType)
			{
				case XamlNodeType.NamespaceDeclaration:
					xow.WriteNamespace(base.Namespace);
					break;
				case XamlNodeType.StartObject:
					xow.WriteStartObject(base.Type);
					break;
				case XamlNodeType.EndObject:
					xow.inject_ctor_arg();    // <--- !! (not shown)
					xow.WriteEndObject();
					break;
				case XamlNodeType.StartMember:
					xow.inject_ctor_arg();    // <--- !! (not shown)
					xow.WriteStartMember(base.Member);
					break;
				case XamlNodeType.EndMember:
					xow.WriteEndMember();
					break;
				case XamlNodeType.GetObject:
					xow.WriteGetObject();
					break;
				case XamlNodeType.Value:
					xow.WriteValue(base.Value);
					break;
				case XamlNodeType.None:
					break;
			}
		}
	}
