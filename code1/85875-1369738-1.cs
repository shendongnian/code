    List<string> directoriesToDelete = new List<string>();
    DirectoryWalker walker = new DirectoryWalker(@"C:\pathToSource\src",
        dir => {
            if (Directory.GetFileSystemEntries(dir).Length == 0) {
                directoriesToDelete.Add(dir);
                return false;
            }
            return true;
        },
        file => {
            if (FileIsTooOld(file)) {
                return true;
            }
            return false;
        }
        );
    foreach (string file in walker)
        File.Delete(file);
    foreach (string dir in directoriesToDelete)
        Directory.Delete(dir);
