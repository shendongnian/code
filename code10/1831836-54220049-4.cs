    using Amazon.S3;
    using Amazon.S3.Model;
    public async Task<IActionResult> Upload(IFormFile file)
    {
        BasicAWSCredentials awsCredentials = new BasicAWSCredentials("accessKey", "secretKey");
        IAmazonS3 clientAws = new AmazonS3Client(awsCredentials, Amazon.RegionEndpoint.EUCentral1);
        string urlTemp = Path.GetTempFileName();
        string extension = Path.GetExtension(file.FileName);
        Guid guid = Guid.NewGuid();
        string nameFile = guid + extension;
        string contentType = file.ContentType;
        using (var fileStream = new FileStream(urlTemp, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        try
        {
            // simple object put
            using (clientAws)
            {
                var request = new PutObjectRequest()
                {
                    BucketName = "yourbucket",
                    Key = nameFile,
                    FilePath = urlTemp,
                    ContentType = contentType
                };
                var response = await clientAws.PutObjectAsync(request);
                //write in your db
            }
        }
        catch (AmazonS3Exception amazonS3Exception)
        {
            if (amazonS3Exception.ErrorCode != null &&
                (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
            {
                Console.WriteLine("Please check the provided AWS Credentials.");
                Console.WriteLine("If you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
            }
            else
            {
                Console.WriteLine("An error occurred with the message '{0}' when writing an object", amazonS3Exception.Message);
            }
        }
        return Ok();
    }
    public async Task<IActionResult> Download(string file)
    {
        try
        {
            BasicAWSCredentials awsCredentials = new BasicAWSCredentials("accessKey", "secretKey");
            IAmazonS3 clientAws = new AmazonS3Client(awsCredentials, Amazon.RegionEndpoint.EUCentral1);
            GetObjectResponse response = new GetObjectResponse();
            string urlTemp = Path.GetTempPath();
            Guid guid = Guid.NewGuid();
            string nameFile = guid + ".pdf";
            try
            {
                // simple object put
                using (clientAws)
                {
                    GetObjectRequest request = new GetObjectRequest();
                    request.BucketName = "yourBucket";
                    request.Key = file;
                    response = await clientAws.GetObjectAsync(request);
                    CancellationTokenSource source = new CancellationTokenSource();
                    CancellationToken token = source.Token;
                    await response.WriteResponseStreamToFileAsync(urlTemp + nameFile, true, token);
                    var path = urlTemp + nameFile;
                    var memory = new MemoryStream();
                    using (var stream = new FileStream(path, FileMode.Open))
                    {
                        await stream.CopyToAsync(memory);
                    }
                    memory.Position = 0;
                    var fsResult = new FileStreamResult(memory, "application/pdf");
                    return fsResult;
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    Console.WriteLine("Please check the provided AWS Credentials.");
                    Console.WriteLine("If you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
                }
                else
                {
                    Console.WriteLine("An error occurred with the message '{0}' when writing an object", amazonS3Exception.Message);
                }
            }
        }
        catch (Exception ex)
        {
            //throw;
        }
        return View();
    }
