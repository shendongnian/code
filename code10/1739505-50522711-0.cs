    var fabricClient = new FabricClient();
    var nodes = await fabricClient.QueryManager.GetNodeListAsync("");
    var apps = fabricClient.QueryManager.GetApplicationListAsync().Result;
    foreach (var app in apps)
    {
        Console.WriteLine($"Discovered application:'{app.ApplicationName}");
        var deployedPartitions = new Dictionary<Guid, List<string>>();
        foreach (var node in nodes)
        {
            //get deployed partitions per node
            var deployed = await fabricClient.QueryManager.GetDeployedReplicaListAsync(node.NodeName, app.ApplicationName);
                    
            foreach (var dep in deployed)
            {
                 List<string> list;
                 if (!deployedPartitions.TryGetValue(dep.Partitionid, out list))
                 {
                      list = new List<string>();
                      deployedPartitions.Add(dep.Partitionid, list);
                 }
                 list.Add(node.NodeName);
             }
         }
         var services = await fabricClient.QueryManager.GetServiceListAsync(app.ApplicationName);
         foreach (var service in services)
         {
             Console.WriteLine($"Discovered Service:'{service.ServiceName}");
             var partitions = await fabricClient.QueryManager.GetPartitionListAsync(service.ServiceName);
             foreach (var partition in partitions)
             {
                  var partitionId = partition.PartitionInformation.Id;
                  if (deployedPartitions.TryGetValue(partitionId, out var nodeNames))
                  {
                      Console.WriteLine($"Discovered {service.ServiceKind} Service:'{service.ServiceName} PartitionId: '{partitionId}' running on nodes {string.Join(", ", nodeNames)}");
                  }
             }
        }
     }
