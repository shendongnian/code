    [HttpPost]
    public async Task<bool> Upload()
    {
        try
        {
            using(var requestStream = await Request.Content.ReadAsStreamAsync())
            {
                PutRecordRequest putRecord = new PutRecordRequest();
                putRecord.DeliveryStreamName = myStreamName;
                Record record = new Record();
                record.Data = requestStream ;
                putRecord.Record = record;
                await kinesisClient.PutRecordAsync(putRecord);
                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    
        return true;
    }
