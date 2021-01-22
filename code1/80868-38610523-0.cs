    private void ClearFolder(string FolderName)
{
    DirectoryInfo dir = new DirectoryInfo(FolderName);
    foreach (FileInfo fi in dir.GetFiles())
    {
        fi.IsReadOnly = false;
        fi.Delete();
    }
    foreach (DirectoryInfo di in dir.GetDirectories())
    {
        ClearFolder(di.FullName);
        di.Delete();
    }
