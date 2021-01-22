        /// <summary> (1) Creates a 'Resource' pack URI .</summary>
        public static Uri CreatePackUri(Assembly assembly, string path, PackType packType)
        {
            Check.RequireNotNull(assembly);
            Check.RequireStringValue(path, "path");
            const string startString = "pack://application:,,,/{0};component/{1}";
            string packString;
            switch (packType)
            {
                case PackType.ReferencedAssemblySimpleName:
                    packString = string.Format(startString, assembly.GetName().Name, path);
                    break;
                case PackType.ReferencedAssemblyAllAvailableParts:
                    // exercise for the reader
                    break;
                default:
                    throw new ArgumentOutOfRangeException("packType");
            }
            return new Uri(packString);
        }
        /// <summary>(2) Verify the resource is located where I think it is.</summary>
        public static bool ResourceExists(Assembly assembly, string resourcePath)
        {
            return GetResourcePaths(assembly).Contains(resourcePath.ToLowerInvariant());
        }
        public static IEnumerable<object> GetResourcePaths(Assembly assembly, CultureInfo culture)
        {
            var resourceName = assembly.GetName().Name + ".g";
            var resourceManager = new ResourceManager(resourceName, assembly);
            try
            {
                var resourceSet = resourceManager.GetResourceSet(culture, true, true);
                foreach (DictionaryEntry resource in resourceSet)
                {
                    yield return resource.Key;
                }
            }
            finally
            {
                resourceManager.ReleaseAllResources();
            }
        }
        /// <summary>(3) Verify the uri can construct an image.</summary>
        public static bool CanCreateImageFrom(Uri uri)
        {
            try
            {
                var bm = new BitmapImage(uri);
                return bm.UriSource == uri;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
