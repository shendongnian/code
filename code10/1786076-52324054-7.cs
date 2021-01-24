    var sampleCount = 100; // Or whatever
    var sampleInterval = 10;
    var recordedDataHeader = new RecordedDataHeader
    {
        SoftwareVersion = softwareVersion,
        CalibrationConfiguration = calibrationConfiguration,
        RepresentationConfiguration = representationConfiguration,
    };
    var settings = new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
    };
    // Write the header
    Console.WriteLine("Beginning serialization of sample data to {0}.", this.filePath);
    using (var stream = new FileStream(this.filePath, FileMode.Create))
    {
        JsonExtensions.ToNewlineDelimitedJson(stream, new[] { recordedDataHeader });
    }
    // Write each sample incrementally
    for (int i = 0; i < sampleCount; i++)
    {
        Thread.Sleep(sampleInterval);
        Console.WriteLine("Performing sample {0} of {1}", i, sampleCount);
        var map = GetPressureMap(i);
        using (var stream = new FileStream(this.filePath, FileMode.Append))
        {
            JsonExtensions.ToNewlineDelimitedJson(stream, new[] { map });
        }
    }
    Console.WriteLine("Finished serialization of sample data to {0}.", this.filePath);
