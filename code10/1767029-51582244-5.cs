        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            var result = new List<ServicePartitionInformation>();
            ServicePartitionList partitions = await new FabricClient().QueryManager.GetPartitionListAsync(Context.ServiceName).ConfigureAwait(false);
            foreach (var partition in partitions)
            {
                result.Add(partition.PartitionInformation);
            }
            var info = JsonConvert.SerializeObject(result);
            Console.WriteLine(info);
        }
