      public class KMLClass
      {
      public static  GoogleMap gmap;
        public KMLClass(GoogleMap map)
        {
            if(gmap==null)
            {
                if(map!=null)
                {
                    gmap = map;
                }
            }
        }
        public void AddKML()
        {
            GeoJsonLayer layer = new GeoJsonLayer(gmap, Resource.Raw.jsonFile, Android.App.Application.Context);
            layer.AddLayerToMap();
        }
