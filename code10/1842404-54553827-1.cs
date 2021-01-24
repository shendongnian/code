    var ranges = new[]
    {
        new CityStateRaw { Range = "{\"city\":\"REDMOND\",\"state\":\"AK\"}" },
        new CityStateRaw { Range = "{\"city\":\"Alex City\",\"state\":\"foo\"}" },
    };
    var list = ranges
        .Select(raw => JsonConvert.DeserializeObject<CityState>(raw.Range))
        .ToList();
