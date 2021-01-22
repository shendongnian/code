    String codeGenerationXmlns = "http://schemas.microsoft.com/ado/2006/04/codegeneration";
    EdmItemCollection edmItems = new EdmItemCollection(new XmlReader[] { csdlReader });
    var ownEntities = from item in edmItems
    				  where item.BuiltInTypeKind == BuiltInTypeKind.EntityType
    				  select item as EntityTypeBase;
    var entityContainer = (from item in edmItems
    					   where item.BuiltInTypeKind == BuiltInTypeKind.EntityContainer
    					   select item as EntityContainer).FirstOrDefault();
    Entities = (from ent in ownEntities
    			select new Entity
    			{
    				Name = ent.Name,
    				SetName = (from entSet in entityContainer.BaseEntitySets
    						   where (entSet.ElementType == ent) || (ent.BaseType != null && (entSet.ElementType.FullName.Equals(ent.BaseType.FullName)))
    						   select entSet.Name).FirstOrDefault(),
    				IsPublic = ((from metaProps in ent.MetadataProperties
    							 where metaProps.Name.Equals(codeGenerationXmlns + ":TypeAccess")
    							 select metaProps.Value).FirstOrDefault() ?? "Public").Equals("Public"),
    				Keys = (from keys in ent.KeyMembers
    						select new Entity.Member
    						{
    							Name = keys.Name,
    							Type = keys.TypeUsage.EdmType.Name
    						}).ToList(),
    				Properties = (from prop in ent.Members
    							  select new Entity.Member
    							  {
    								  Name = prop.Name,
    								  Type = prop.TypeUsage.EdmType.Name,
    								  IsCollection = prop.TypeUsage.EdmType.BuiltInTypeKind == BuiltInTypeKind.CollectionType,
    								  PrivateGetter = ((from metaProps in prop.MetadataProperties
    													where metaProps.Name.Equals(codeGenerationXmlns + ":GetterAccess")
    													select metaProps.Value).FirstOrDefault() ?? "Public").Equals("Private"),
    								  PrivateSetter = ((from metaProps in prop.MetadataProperties
    													where metaProps.Name.Equals(codeGenerationXmlns + ":SetterAccess")
    													select metaProps.Value).FirstOrDefault() ?? "Public").Equals("Private"),
    							  }).ToList()
    			}).ToList();
