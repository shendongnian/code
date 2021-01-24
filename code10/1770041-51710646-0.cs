	public class TempFileDialogHandler : IDialogHandler
	{
		string[] _filePath;
		public TempFileDialogHandler(params string[] filePath)
		{
			_filePath = filePath;
		}
		public bool OnFileDialog(IWebBrowser browserControl, IBrowser browser, CefFileDialogMode mode, string title, string defaultFilePath, List<string> acceptFilters, int selectedAcceptFilter, IFileDialogCallback callback)
		{
			callback.Continue(0, _filePath.ToList());
			return true;
		}
	}
