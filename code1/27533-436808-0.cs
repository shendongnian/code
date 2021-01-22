    S3Client s3 = new S3Client("myAWSKey", "MyAWSPassword");
     
    bool success = s3.Connect();
    
    S3Client s3 = new S3Client("key", "secret"):
    var buckets = from b in s3.Buckets
                               where b.Name == "demo"
                               select b;
    foreach(Bucket b in buckets)
    {
         Console.WriteLine(b.About());
    }
