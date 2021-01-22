    // Fields
    Dictionary<string, Tuple<long, long>> data
         = new Dictionary<string, Tuple<long, long>>();
    bool IsInternetIdle()
    {
        bool idle = true;
        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
        foreach (var adapter in adapters)
        {
            var stats = adapter.GetIPStatistics();
            Tuple<long, long> info;
            if (!data.TryGetValue(adapter.Name, out info))
            {
                //New Adapter
                info = new Tuple<long, long>
                (
                    stats .BytesReceived,
                    stats .BytesSent
                );
                data.Add(adapter.Name, info);
            }
            else
            {
                if
                (
                    info.Item1 != stats .BytesReceived
                    || info.Item2 != stats .BytesSent
                )
                {
                    idle = false;
                    break;
                }
            }
        }
        //Console.WriteLine("Is Idle: {0}", idle.ToString());
        return idle;
    }
