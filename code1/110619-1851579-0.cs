string GetFileType(string path)
{
   Shell32.ShellClass shell = new Shell32.ShellClass();
   Shell32.Folder folder = shell.NameSpace(Path.GetDirectoryName(path));
   Shell32.FolderItem item = folder.ParseName(Path.GetFileName(path));
   return folder.GetDetailsOf(item, 2);
}
