    private static MyDisk ConvertToMyDisk(PSMemberInfoCollection<PSMemberInfo> item)
    {
        return new MyDisk
        {
            AllocatedSize = long.Parse(item["AllocatedSize")].Value.ToString()),
            FriendlyName = item["FriendlyName"].Value.ToString(),
            IsBoot = bool.Parse(item["IsBoot"].Value.ToString()),
            Number = int.Parse(item["Number"].Value.ToString())
        };
    }
