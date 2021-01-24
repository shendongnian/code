    public class ClusterCreator
    {
        public Dictionary<int, SimpleCluster> GetClusters(List<SimpleCluster> clusterList, int maxDistance)
        {
            //LOAD DATA
            //var clusterList = new List<SimpleCluster>(); // LoadSimpleClusterList();
            //var latitudeSensitivity = 3;
            //var longitutdeSensitivity = 3;
            //CLUSTER THE DATA
            return ClusterTheData(clusterList, maxDistance);
        }
        public Dictionary<int, SimpleCluster> ClusterTheData(List<SimpleCluster> clusterList, int maxDistance)
        {
            //CLUSTER DICTIONARY
            var clusterDictionary = new Dictionary<int, SimpleCluster>();
            //Add the first node to the cluster list
            if (clusterList.Count > 0)
            {
                clusterDictionary.Add(clusterList[0].ID, clusterList[0]);
            }
            //ALGORITHM
            for (int i = 1; i < clusterList.Count; i++)
            {
                SimpleCluster combinedCluster = null;
                SimpleCluster oldCluster = null;
                foreach (var clusterDict in clusterDictionary)
                {
                    //Check if the current item belongs to any of the existing clusters
                    if (CheckIfInCluster(clusterDict.Value, clusterList[i], maxDistance))
                    {
                        //If it belongs to the cluster then combine them and copy the cluster to oldCluster variable;
                        combinedCluster = CombineClusters(clusterDict.Value, clusterList[i]);
                        oldCluster = new SimpleCluster(clusterDict.Value);
                    }
                }
                //This check means that no suitable clusters were found to combine, so the current item in the list becomes a new cluster.
                if (combinedCluster == null)
                {
                    //Adding new cluster to the cluster dictionary 
                    clusterDictionary.Add(clusterList[i].ID, clusterList[i]);
                }
                else
                {
                    //We have created a combined cluster. Now it is time to remove the old cluster from the dictionary and instead of it add a new cluster.
                    clusterDictionary.Remove(oldCluster.ID);
                    clusterDictionary.Add(combinedCluster.ID, combinedCluster);
                }
            }
            return clusterDictionary;
        }
        public static SimpleCluster CombineClusters(SimpleCluster home, SimpleCluster imposter)
        {
            //Deep copy of the home object
            var combinedCluster = new SimpleCluster(home);
            combinedCluster.LAT_LON_LIST.AddRange(imposter.LAT_LON_LIST);
            combinedCluster.NAMES.AddRange(imposter.NAMES);
            //Combine the data of both clusters
            //combinedCluster.LAT_LON_LIST.AddRange(imposter.LAT_LON_LIST);
            //combinedCluster.NAMES.AddRange(imposter.NAMES);
            //Recalibrate the new center
            combinedCluster.LAT_LON_CENTER = new LAT_LONG
            {
                LATITUDE = ((home.LAT_LON_CENTER.LATITUDE + imposter.LAT_LON_CENTER.LATITUDE) / 2.0),
                LONGITUDE = ((home.LAT_LON_CENTER.LONGITUDE + imposter.LAT_LON_CENTER.LONGITUDE) / 2.0)
            };
            return combinedCluster;
        }
        public bool CheckIfInCluster(SimpleCluster home, SimpleCluster imposter, int maxDistance)
        {
            foreach (var item in home.LAT_LON_LIST)
            {
                var sCoord = new GeoCoordinate(item.LATITUDE, item.LONGITUDE);
                var eCoord = new GeoCoordinate(imposter.LAT_LON_CENTER.LATITUDE, imposter.LAT_LON_CENTER.LONGITUDE);
                var distance = sCoord.GetDistanceTo(eCoord);
                if (distance <= maxDistance)
                    return true;
            }
            return false;
            
            //if ((home.LAT_LON_CENTER.LATITUDE + latitudeSensitivity) > imposter.LAT_LON_CENTER.LATITUDE
            //       && (home.LAT_LON_CENTER.LATITUDE - latitudeSensitivity) < imposter.LAT_LON_CENTER.LATITUDE
            //       && (home.LAT_LON_CENTER.LONGITUDE + longitutdeSensitivity) > imposter.LAT_LON_CENTER.LONGITUDE
            //       && (home.LAT_LON_CENTER.LONGITUDE - longitutdeSensitivity) < imposter.LAT_LON_CENTER.LONGITUDE
            //   )
            //{
            //    return true;
            //}
            //return false;
        }
        
    }
    public class SimpleCluster
    {
        #region Constructors
        public SimpleCluster(int id, string name, double latitude, double longitude)
        {
            ID = id;
            LAT_LON_CENTER = new LAT_LONG
            {
                LATITUDE = latitude,
                LONGITUDE = longitude
            };
            NAMES = new List<string>();
            NAMES.Add(name);
            LAT_LON_LIST = new List<LAT_LONG>();
            LAT_LON_LIST.Add(LAT_LON_CENTER);
        }
        public SimpleCluster(SimpleCluster old)
        {
            ID = old.ID;
            LAT_LON_CENTER = new LAT_LONG
            {
                LATITUDE = old.LAT_LON_CENTER.LATITUDE,
                LONGITUDE = old.LAT_LON_CENTER.LONGITUDE
            };
            LAT_LON_LIST = new List<LAT_LONG>(old.LAT_LON_LIST);
            NAMES = new List<string>(old.NAMES);
        }
        #endregion
        public int ID { get; set; }
        public List<string> NAMES { get; set; }
        public LAT_LONG LAT_LON_CENTER { get; set; }
        public List<LAT_LONG> LAT_LON_LIST { get; set; }
    }
    public class LAT_LONG
    {
        public double LATITUDE { get; set; }
        public double LONGITUDE { get; set; }
    }
