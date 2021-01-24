 	public class IndexModel : PageModel
	{
		private readonly IFileProvider _fileProvider;
		public IndexModel(IFileProvider fileProvider)
		{
			_fileProvider = fileProvider;
		}
		public IFileInfo FileInfo { get; private set; }
		public void OnGet()
		{
			IFileInfo = _fileProvider.GetFileInfo("filename.ext");
		}
	}	
