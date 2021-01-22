    Regex regex = new Regex(...);
    var deviceIds = ctx.Devices.Select(d => DeviceId).AsEnumerable();
    var matchingIds = deviceIds.Where(id => regex.IsMatch(id))
                               .ToList();
    var devices = ctx.Devices.Where(d => matchingIds.Contains(d.DeviceId));
