        foreach (var folder in Directory.GetDirectories(myDir, "*", System.IO.SearchOption.AllDirectories))
        {
            {
                if (Directory.GetFiles(folder, "*", System.IO.SearchOption.AllDirectories).Length == 0)
                    Directory.Delete(folder, true);
            }
        }
