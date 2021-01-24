	var metaDataRequest = new RetrieveAllEntitiesRequest
	{
		EntityFilters = EntityFilters.All
	};
	var metaDataResponse = (RetrieveAllEntitiesResponse)svc.Execute(metaDataRequest);
	var OriginEntities = metaDataResponse.EntityMetadata.ToList();
	foreach (var entity in OriginEntities.Where(e=> e.IsCustomizable.Value))
	{
		foreach (var relationship in entity.OneToManyRelationships.Where(r => r.IsCustomRelationship == true))
		{
			var lookup = OriginEntities
				.Where(e => e.LogicalName == relationship.ReferencingEntity)
				.Single()
				.Attributes
				.Where(a => a.AttributeType == AttributeTypeCode.Lookup && a.LogicalName == relationship.ReferencingAttribute)
				.Single();
			var createOtm = new CreateOneToManyRequest()
			{
				OneToManyRelationship = relationship,
				Lookup = lookup as LookupAttributeMetadata
			};
		}
	}
