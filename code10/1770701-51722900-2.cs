     public class JsonLayerAdd : IGeoJsonLayer
    {
        GoogleMap map = null;
        public void AddLayerJson()
        {
            KMLClass _map = new KMLClass(map);
            _map.AddKML();
        }
    }
