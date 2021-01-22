    // Divide into 3x3 pixel clusters
    var currentCluster = new Point((int)touchPos.X / 3, (int)touchPos.Y / 3)
    // previousClusters is a List<Point>() which is cleared on TouchUp
    foreach (var cluster in previousClusters)
    {
        if (cluster == currentCluster)
        {
            // We've been here before, do your magic here!
            g1.Background = Brushes.AliceBlue;
            // Return here, since we don't want to add the point again
            return;
        }
    }
    previousClusters.Add(currentCluster);
