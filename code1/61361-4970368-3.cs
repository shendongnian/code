<Ids>
<id>C:\videotest\file0.txt</id>
<id>C:\videotest\file1.txt</id>
</Ids>
    class FileFormat
        {
            public FileFormat(string path)
            {
                this.path = path;
            }
            public string FullPath
            {
                get { return Path.GetFullPath(path); }
            }
            public string FileName
            {
                get { return Path.GetFileName(path); }
            }
            private string path;
        }
    List<FileFormat> Files =
            selectedNode
            .Descendants("Ids")
            .Elements("Id")
            .Select(x => new FileFormat(x.Value))
            .Where(s => s.FileName!=string.Empty)
            .ToList();
