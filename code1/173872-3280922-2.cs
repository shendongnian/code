    private string GetStructureRecursiveForCsv(DirectoryInfo directoryInfo, string searchPattern, int level)
    {
        var sb = new StringBuilder();
        var indentation = level;
        sb.Append(new String(';', indentation));
        sb.AppendLine(directoryInfo.Name);
        foreach (var directory in directoryInfo.GetDirectories())
        {
            sb.Append(GetStructureRecursiveForCsv(directory, searchPattern, level+1));
        }
        var groupedByExtension = directoryInfo.GetFiles(searchPattern)
                                              .GroupBy(file => file.Extension)
                                              .Select(group => new { Group = group.Key, Count = group.Count() });
        foreach (var entry in groupedByExtension)
        {
            sb.Append(new String(';', indentation));
            sb.AppendLine(String.Format(";{0};{1}", entry.Group, entry.Count));
        }
        return sb.ToString();
    }
