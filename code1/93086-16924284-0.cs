        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            if (_IsLayoutFile(virtualPath))
            {
                return null;
            }
            return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
        public override String GetFileHash(String virtualPath, IEnumerable virtualPathDependencies)
        {
            if (_IsLayoutFile(virtualPath))
            {
                return Guid.NewGuid().ToString();
            }
            return Previous.GetFileHash(virtualPath, virtualPathDependencies);
        }
