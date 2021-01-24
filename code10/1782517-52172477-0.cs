    List<string> channels = Enum.GetNames(typeof(ModbusChannels)).ToList();
    IEnumerable<ChannelValueType> allChannelValues = Enumerable.Empty<ChannelValueType>();
    foreach (string item in channels)
    {
        IEnumerable<ChannelValueType> channelValues = from x in data
                                                      where x.ChannelName.Contains(item)
                                                      select x.ChannelValue;
        
        allChannelValues = allChannelValues.Concat(channelValues);
    }
    string allChannelValuesText = string.Join(", ", allChannelValues);
