    public delegate void CollectEventHandler(object source, MapEventArgs args);
    public class MapEventArgs : EventArgs
    {
        public IEnumerable<Map> Maps { get; set; }
    }
