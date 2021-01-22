    Dictionary<string, string> args = new Dictionary<string, string>
    {
        {"computer", serviceConfig.Computer},
        {"ver", string.Format("{0}.{1}.{2}",
            serviceConfig.Version.Major,
            serviceConfig.Version.Minor,
            serviceConfig.Version.Build)},
        {"from", userName},
        {"realcomputername", Environment.MachineName},
        {"type", type},
        {"Channels", serviceConfig.ChannelsString},
        {"Hotkeys", serviceConfig.HotKeysString},
        {"ID", serviceConfig.AlarmGroupName},
    };
    string login = string.Join("&", args.Select(arg =>
        string.Format("{0}={1}", arg.Key, arg.Value)).ToArray());
