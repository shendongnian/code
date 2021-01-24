    var samples = context.Samples.AsQueryable();
    if (!string.IsNullOrEmpty(sampleParams.Gender))
    {
        samples = samples.Where(u => u.Gender == sampleParams.Gender);
    }
