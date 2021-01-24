	public interface IFormActionBuilder {
		IFormActionBuilder HasFormId(
			string formId);
		IFormActionBuilder HasLabel(
			string label);
		IFormActionBuilder IsDefault();
		IFormActionBuilder IsFileUpload();
	}
	public interface IFormActionMetadata {
		string Controller { get; }
		bool Default { get; }
		string FormId { get; }
		string Enctype { get; }
		string Label { get; }
		string Name { get; }
	}
