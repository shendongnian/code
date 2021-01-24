    HttpClient client = new HttpClient(); // maybe configure it
    async Task ProcessRow(Row row) // put here the correct type
    {
        try
        {
            var str = await client.GetStringAsync(row[address]);
            AppendTextBox(str, txtBoxResponse);
        }
        catch (HttpRequestException ex)
        {
            AppendTextBox(row["ssub_msisdn"] + ", Error: " + ex.Message, txtBoxResponse);
        }
    }
    var tasks = dt.AsEnumerable().Select(row => ProcessRow(row));
    await Yask.WhenAll(tasks);
