    var _channels = new List<(string, string)>();
    
    foreach(var c in channels)
    {
        var channeltypes = channels.Where(x => x.ChannelName == c.ChannelName && x.ChannelType != null);
        if(channeltypes.Any())
        {
            _channels.Add((channeltypes[0].ChannelName, channeltypes[0].ChannelType));
        } else {
            _channels.Add((c.ChannelName, null));
        }
    }
