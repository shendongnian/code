    var transformed = grouped.Select(g => new
    {
        Hubs = g.Select(hub => new
        {
           stamp = g.Key,
           Latency0 = g.FirstOrDefault(item => item.Uplink == "0")?.Latency,
           Latency1 = g.FirstOrDefault(item => item.Uplink == "1")?.Latency,
           Latency2 = g.FirstOrDefault(item => item.Uplink == "2")?.Latency,
           Latency3 = g.FirstOrDefault(item => item.Uplink == "3")?.Latency,
           Latency4 = g.FirstOrDefault(item => item.Uplink == "4")?.Latency,
        })
    });
