    var av = new AllValues();
    using (var data = new ModelData())
    {
        av.ShortRunTime = data.Values.FirstOrDefault(c => c.name == "ShortRunTime")?.Value;
        av.MediumRunTime = data.Values.FirstOrDefault(c => c.name == "MediumRunTime")?.Value;
         // ...
    }
