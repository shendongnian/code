    static IEnumerable<string> recurseFolder(String Folder)
    {
        if (Directory.Exists(Folder))
        {
            string[] files = null;
            string[] dirs = null;
            try { files = Directory.GetFiles(Folder); } catch (Exception) { }
            if (files != null)
            {
                foreach (var item in files.OrderBy(o => o))
                {
                    yield return item;
                }
            }
            try { dirs = Directory.GetDirectories(Folder); } catch (Exception) { }
            if (dirs != null)
            {
                foreach (var dir in dirs.OrderBy(o =>o))
                {
                    foreach (var item in recurseFolder(dir))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
