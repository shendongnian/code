    public interface IPlugin
	{
		string Name { get; }
		string AuthorName { get; }
		byte[] Icon();
		object View { get; }
	}
