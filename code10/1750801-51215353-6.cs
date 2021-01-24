	public void IncludeBase<TObjectBase>() {
		var baseBuilder = DocumentLoader.Get<TObjectBase>();
		if (baseBuilder == null) {
			return;
		}
		foreach (var basePropertyMetadata in baseBuilder.PropertyMetadatas) {
			var propertyMetadata = PropertyMetadatas.SingleOrDefault(
				pm => pm.Name == basePropertyMetadata.Name);
			if (propertyMetadata == null) {
				continue;
			}
			propertyMetadata = basePropertyMetadata;
		}
	}
