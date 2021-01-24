    public interface IOpenFileService
    {
	/// <summary>
	/// Open  file
	/// </summary>
	/// <returns>True if file selected</returns>
	bool? OpenFile();
	/// <summary>
	/// Full names of the selected files
	/// </summary>
	string[] FileNames { get; }
    }
    public class OpenFileService: IOpenFileService
    {
        OpenFileDialog _openFileDialog = new OpenFileDialog();
        string[] _selectedFileNames;
        public bool? OpenFile()
        {
            _openFileDialog.Multiselect = true;
            var ofd = _openFileDialog.ShowDialog();
            if (ofd.HasValue && ofd.Value)
            {
                _selectedFileNames = _openFileDialog.FileNames; 
            }
            return ofd;
        }
        public string[] FileNames
        {
            get { return _selectedFileNames ; }
        }
    }
