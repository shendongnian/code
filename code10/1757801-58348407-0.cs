    public class S3ClientFactory : IS3ClientFactory
    {        
        private IDictionary<string, IAmazonS3> _container = null;
        private S3ClientFactory()
        {
            _container = new Dictionary<string, IAmazonS3>();
        }
        public static IS3ClientFactory Create(string[] regions, AWSOptions options)
        {
            var factory = new S3ClientFactory();
            foreach (var region in regions)
            {
                var regionEndPoint = RegionEndpoint.GetBySystemName(region);
                options.Region = regionEndPoint;
                factory._container.Add(region, options.CreateServiceClient<IAmazonS3>());
            }
            return factory;
        }
		
		public IAmazonS3 GetS3Client(string region)
        {
            if (!_container.ContainsKey(region))
            {
                throw new Exception(string.Format("Could not find s3 client for key {0}", region));
            }
            return _container[region];
        }
	}
