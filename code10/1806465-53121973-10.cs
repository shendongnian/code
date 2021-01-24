	public interface IDataRepositoryConfiguration
	{
		//nothing required; this is just so we've got a common base class
	}
	public class FileRepositoryConfiguration: IDataRepositoryConfiguration
	{
		public string WorkingFolder {get;set;}
	}
	public class FileRepository : IDataRepository {
		public FileRepository (IDataRepositoryConfiguration configuration)
		{
			var config = configuration as FileRepositoryConfiguration;
			if (config == null) throw new ArgumentException(nameof(configuration)); //improve by having different errors for null config vs config of unsupported type
			this.WorkingFolder = config.WorkingFolder;
		}
		//...
	}
