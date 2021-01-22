    var doc = new XmlDocument();
    var xml =
        @"<DriveLayout>
    <Drive totalSpace='16' VolumeGroup='dg01' />
    <Drive totalSpace='32' VolumeGroup='dg01' />
    <Drive totalSpace='64' VolumeGroup='dg02' />
    <Drive totalSpace='64' VolumeGroup='dg02' />
    <VolumeGroups>
    <VolumeGroup VolumeGroup='dg01' storageTier='1' />
    <VolumeGroup VolumeGroup='dg02' storageTier='2' />
    </VolumeGroups>
    </DriveLayout>
    ";
    doc.LoadXml(xml);
    var volumeGroups = doc.SelectNodes("/DriveLayout/VolumeGroups/VolumeGroup");
    var storageTiers = new Dictionary<string, string>();
    if (volumeGroups != null)
    {
        foreach (var volumeGroup in volumeGroups)
        {
            var volumeGroupElement = (XmlElement) volumeGroup;
            storageTiers.Add(
                volumeGroupElement.Attributes["VolumeGroup"].Value,
                volumeGroupElement.Attributes["storageTier"].Value);
        }
    }
    var nodes = doc.SelectNodes("/DriveLayout/Drive");
    if (nodes == null)
    {
        return;
    }
    
    foreach (XmlNode node in nodes)
    {
        var element = (XmlElement) node;
        var volumeGroupAttribute = element.Attributes["VolumeGroup"];
        if (volumeGroupAttribute == null)
        {
            continue;
        }
        var volumeGroup = volumeGroupAttribute.Value;
        var newStorageTier = doc.CreateAttribute("storageTier");
        newStorageTier.Value = storageTiers[volumeGroup];
        element.Attributes.Append(newStorageTier);
    }
