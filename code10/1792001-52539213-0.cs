    using (var writer = new StreamWriter(@"C:\Clean.csv")) {
        var data = new List<ClusterData>();
        //...assuming data is poulated
        var dataToCsv = data.SelectMany(item => item.FileName.Select(filename => new {
            FileName = filename,
            ClusterNumber = item.ClusterNumber,
            TopTerm = item.TopTerm
        }));
        var csv = new CsvWriter(writer);
        csv.WriteRecords(dataToCsv);
    }
