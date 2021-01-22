    HashSet<Cluster> clusterList = new HashSet<Cluster>();
    foreach (Cluster cluster in clustersByProgramme)
    {
     if (!clusterList.Contains(cluster))
         clusterList.Add(cluster);
    }
