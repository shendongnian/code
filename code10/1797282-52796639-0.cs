    // Create some very badly 'mocked' data
    var idColumn = new DataColumn(
        new DataField<int>("id"),
        Enumerable.Range(0, 10000).Select(i => i).ToArray());
    var cityColumn = new DataColumn(
        new DataField<string>("city"),
        Enumerable.Range(0, 10000).Select(i => i % 2 == 0 ? "London" : "Grimsby").ToArray());
    var schema = new Schema(idColumn.Field, cityColumn.Field);
    using (var pipeStream = new PipeStream())
    {
        var buffer = new byte[4096];
        int read = 0;
        var readTask = Task.Run(async () =>
        {
            //transferUtil.Upload(readStream, "bucketName", "key"); // Execute this in a Task / Thread 
            while ((read = await pipeStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                var incoming = Encoding.ASCII.GetString(buffer, 0, read);
                Console.WriteLine(incoming);
                // await Task.Delay(5000); uncomment this to simulate very slow consumer
            }
        });
        using (var parquetWriter = new ParquetWriter(schema, pipeStream)) // This destructor finishes the file and transferUtil closes the stream, so we need this weird using nesting to keep everyone happy.
        using (var rowGroupWriter = parquetWriter.CreateRowGroup())
        {
            rowGroupWriter.WriteColumn(idColumn);  // Step through both these statements to see data read before the parquetWriter completes
            rowGroupWriter.WriteColumn(cityColumn);
        }       
    }
