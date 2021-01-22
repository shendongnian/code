	public interface IHasLengthAndIndexer
	{
		int Length { get; }
		byte this[ int index ] { get; }
	}
