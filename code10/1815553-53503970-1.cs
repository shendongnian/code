    int instances = 0;
    var fabricClient = new FabricClient();
    var partitions = await fabricClient.QueryManager.GetPartitionListAsync(new Uri("fabric:/AppName/ServiceName"));
    foreach (var partition in partitions)
    {
        instances += (await fabricClient.QueryManager.GetReplicaListAsync(partition.PartitionInformation.Id)).Count; // you might consider also: .Where(r => r.ReplicaStatus == ServiceReplicaStatus.Ready).Count()
    }
