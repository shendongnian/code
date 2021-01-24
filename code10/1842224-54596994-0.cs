        [HttpGet]
        public async Task ActionResult<IEnumerable<string>> Get()
        {
            var o = new
            {
                Message = "Hello World"
            };
            byte[] oByte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
            
            var client = new AmazonKinesisClient(<AccessKeyId>, <SecretAccessKey>, <Region>);
            try
            {
                using (MemoryStream ms = new MemoryStream(oByte))
                {
                    PutRecordRequest requestRecord = new PutRecordRequest();
                    // QUESTION 4: What is this stream name??? 
                    requestRecord.StreamName = <your Kinesis stream name>;
                    requestRecord.Data = ms;
                    var response = await client.PutRecordAsync(requestRecord);
                    return Ok(new
                    {
                        seq = response.Result.SequenceNumber
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return new string[] { "value1", "value2" };
        }
