    for (int i = item.File.Versions.Count - 1; i >= 0; i--)
    {
        contents = item.File.Versions[i].OpenBinary();
        SPFile f = aFolder.Files.Add(item.File.Versions[i].File.Name, contents, u1, item.File.Versions[i].CreatedBy, dt1, item.File.Versions[i].Created);
        SPListItem subItem = list.GetItemByID(AID);
        UpdateFields(item.Versions.GetVersionFromLabel(item.File.Versions[i].VersionLabel), subItem);
    }
