    public void OutputStructureToFile(string outputFileName, string folder, string searchPattern)
    {
        using (var file = new StreamWriter(outputFileName))
        {
            file.Write(GetStructure(new DirectoryInfo(folder), searchPattern));
        }
    }
    public string GetStructure(DirectoryInfo directoryInfo, string searchPattern)
    {
        return GetStructureRecursive(directoryInfo, searchPattern, 0);
    }
    private string GetStructureRecursive(DirectoryInfo directoryInfo, string searchPattern, int level)
    {
        var sb = new StringBuilder();
        var indentation = level * 5;
        sb.Append(new String(' ', indentation));
        sb.AppendLine(directoryInfo.Name);
        foreach (var directory in directoryInfo.GetDirectories())
        {
            sb.Append(GetStructureRecursive(directory, searchPattern, level+1));
        }
        var groupedByExtension = directoryInfo.GetFiles(searchPattern)
                                              .GroupBy(file => file.Extension)
                                              .Select(group => new { Group = group.Key, Count = group.Count() });
        foreach (var entry in groupedByExtension)
        {
            sb.Append(new String(' ', indentation));
            sb.AppendLine(String.Format("   {0,10} {1,3}", entry.Group, entry.Count));
        }
        return sb.ToString();
    }
