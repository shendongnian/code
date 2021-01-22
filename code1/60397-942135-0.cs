    serviceResponse = client.Authorize(....);
    var sb = new StringBuilder();
    foreach (CdcEntry element in serviceResponse.Cdc)
    {
        sb.AppendLine(element.Name);
        foreach (CdcEntryItem item in element.Items)
        {
            sb.AppendFormat(" ({0}, {1}) ", item.Key, item.Value);
            sb.AppendLine();
        }
    }
    var authorizeResponse = sb.ToString();
