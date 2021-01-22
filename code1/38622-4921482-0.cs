    foreach (var subDir in dirInfo.GetDirectories())
    {
        DeleteRecursiveFolder(subDir);
    }
    foreach (var file in dirInfo.GetFiles())
    {
        file.Attributes=FileAttributes.Normal;
        file.Delete();
    }
    dirInfo.Delete();
}
