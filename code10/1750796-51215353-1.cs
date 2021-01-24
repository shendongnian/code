	public interface IFormGroupBuilder {
		IFormGroupBuilder HasOrder(
			short order);
	}
	public interface IFormGroupMetadata {
		string Label { get; }
		short Order { get; }
	}
