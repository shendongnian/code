    List<AppData> appointments = new List<AppData>();
    for (int i = results.Count; i > 0; i--)
    {
        appointments.Add(new AppData(results[i], username));
    }
