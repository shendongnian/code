    public void SetDifferences(IEnumerable<Data> datas)
    {
        var fileLookup = new Dictionary<string, List<File>>();
        foreach(var file in datas.SelectMany(d => d.Files))
        {
            if(!fileLookup.TryGetValue(file.Name, out var fileList))
            {
                fileList = new List<File>();
                fileLookup.Add(file.Name, fileList);
            }
            
            if(fileList.Any(f => f.Version != file.Version))
            {
                foreach(var other in fileList)
                {
                    other.FoundDifference = true;
                }
                file.FoundDifference = true;
            }
            fileList.Add(file);
        }
    }
