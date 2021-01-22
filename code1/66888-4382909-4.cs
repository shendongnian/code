    public static class ResourceCacheController
    {
        #region Cached Methods
        public static List<Resource> GetResourcesByProject(Guid gProjectId)
        {
            String sKey = GetCacheKeyProjectResources(gProjectId);
            List<Resource> colItems = CollectionCacheManager.FetchAndCache<Resource>(sKey, delegate() { return ResourceAccess.GetResourcesByProject(gProjectId); });
            return colItems;
        } 
        #endregion
        #region Cache Dependant Methods
        public static int GetResourceCountByProject(Guid gProjectId)
        {
            return GetResourcesByProject(gProjectId).Count;
        }
        public static List<Resource> GetResourcesByIds(Guid gProjectId, List<Guid> colResourceIds)
        {
            if (colResourceIds == null || colResourceIds.Count == 0)
            {
                return null;
            }
            return GetResourcesByProject(gProjectId).FindAll(objRes => colResourceIds.Any(gId => objRes.Id == gId)).ToList();
        }
        public static Resource GetResourceById(Guid gProjectId, Guid gResourceId)
        {
            return GetResourcesByProject(gProjectId).SingleOrDefault(o => o.Id == gResourceId);
        }
        #endregion
        #region Cache Keys and Clear
        public static void ClearCacheProjectResources(Guid gProjectId)
        {            CollectionCacheManager.ClearCollection(GetCacheKeyProjectResources(gProjectId));
        }
        public static string GetCacheKeyProjectResources(Guid gProjectId)
        {
            return string.Concat("ResourceCacheController.ProjectResources.", gProjectId.ToString());
        } 
        #endregion
        internal static void ProcessDeleteResource(Guid gProjectId, Guid gResourceId)
        {
            Resource objRes = GetResourceById(gProjectId, gResourceId);
            if (objRes != null)
            {                CollectionCacheManager.RemoveItemFromCollection(GetCacheKeyProjectResources(gProjectId), objRes);
            }
        }
        internal static void ProcessUpdateResource(Resource objResource)
        {
            CollectionCacheManager.UpdateItem(GetCacheKeyProjectResources(objResource.Id), objResource);
        }
        internal static void ProcessAddResource(Guid gProjectId, Resource objResource)
        {
            CollectionCacheManager.AddItemToCollection(GetCacheKeyProjectResources(gProjectId), objResource);
        }
    }
