public class MyFolderBrowserDialog
{
    public DialogResult MyFolder()
    {
        /// <summary>
        ///   The description of the dialog.
        /// </summary>
        public string Description {get; set;} = "Chose folder...";
		
        /// <summary>
        ///   The ROOT path!
        /// </summary>
        public string RootPath {get; set;} = "";
		
        /// <summary>
        ///   The SelectedPath. Here is no initialization possible.
        /// </summary>
        public string SelectedPath {get; private set;} = "";
    
        /// <summary>
        ///   Shows the dialog...
        /// </summary>
        /// <returns>
        ///   OK, if the user selected a folder or Cancel, if no folder is selected.
        /// </returns>
        public DialogResult ShowDialog()
        {
            var shellType = Type.GetTypeFromProgID("Shell.Application");
            var shell = Activator.CreateInstance(shellType);
            var folder = shellType.InvokeMember(
                             "BrowseForFolder", BindingFlags.InvokeMethod, null,
                             shell, new object[] { 0, Description, 0, RootPath, });
            if (folder is null)
			{
                return DialogResult.Cancel;
			}
            else
            {
                var folderSelf = folder.GetType().InvokeMember(
                                     "Self", BindingFlags.GetProperty, null,
                                     folder, null);
                SelectedPath = folderSelf.GetType().InvokeMember(
                                   "Path", BindingFlags.GetProperty, null,
                                   folderSelf, null) as string;
                // maybe ensure that SelectedPath is set
				return DialogResult.OK;
            }
        }
    }
}
  [1]: https://dotnet-snippets.de/snippet/folderbrowserdialog-mit-benutzerdefiniertem-root/1738
