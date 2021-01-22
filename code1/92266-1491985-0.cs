    try {
      string[] contents = Directory.GetFileSystemEntries(path);
    }
    catch(DirectoryNotFoundException)
    {
      MessageBox.Show("Path not found");
    }
    catch(IOException)
    {
      MessageBox.Show("Could not access path");
    }
