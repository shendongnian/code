	public class DatabaseRepository : IDataRepository {
		DbConnection connection; //you may want a connection string or something else; going with this type just to illustrate that this constructor uses a different type to the FileRepo's
	    public DatabaseRepository(DbConnection connection) 
		{
			this.connection = connection;
		}
		public DataStructure GetData() 
	    {
	       // get data from database
	    }
	}
	public class FileRepository : IDataRepository {
	
	    public string WorkingFolder { get; set; } //Do you need set?  Generally best to keep it constant after initialisation unless there's good reason to change it
		public FileRepository (string workingFolder)
		{
			this.WorkingFolder = workingFolder;
		}
	    public DataStructure GetData() {
	       // get data from files
	    }
	}
