    List<MeanVarianceTestResultsData> results;
    using (var reader = XmlReader.Create(fileName))
    {
        results = MeanVarianceTestResultsDataExtensions.ReadResultListFrom(
            reader,
            m => { m.TestResultImageFile = Path.GetTempFileName(); return File.Open(m.TestResultImageFile, FileMode.Create); },
            s => { s.Dispose(); return null; });
    }
