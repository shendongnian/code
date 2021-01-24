    [assembly: Dependency(typeof(MapService))]
    namespace WorkingWithMaps.iOS
    {
        public class MapService:IMapService
        {
            public MapService()
            {
            }
            public bool HasGoogleMapAvailable()
            {
                var result=UIApplication.SharedApplication.CanOpenUrl(NSUrl.FromString("comgooglemaps-x-callback://"));
                return result;
            }
        }
    }
