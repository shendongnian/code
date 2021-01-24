    public class Location
    {
        public Location (string path, string name){
            Path = path;
            Name = name
        }
        public string Path{ get; private set }
        public string Name{ get; private set }
    }
    Location EN = new Location ("/en","Shop")
