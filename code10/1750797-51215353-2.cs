	public interface IFormPropertyBuilder {
		IFormPropertyBuilder HasFormat(
			string format);
		IFormPropertyBuilder HasLabel(
			string label);
		IFormPropertyBuilder HasOrder(
			short order);
		IFormPropertyBuilder HasType(
			FormFieldType type);
		IFormPropertyBuilder InGroup(
			string group);
		IFormPropertyBuilder IsHidden();
		IFormPropertyBuilder IsReadOnly();
		IFormPropertyBuilder IsRequired();
	}
	public interface IFormPropertyMetadata {
		string Format { get; }
		string Group { get; }
		bool IsIgnored { get; set; }
		string Label { get; }
		string Name { get; }
		short Order { get; }
		bool Required { get; }
		FormFieldType Type { get; }
	}
