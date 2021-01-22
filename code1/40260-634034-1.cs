    public class ULib {
        private string _path, _artist, _title, _album, _length;
        public string Path { get { return _path; } set { _path = value; } }
        public string Artist { get { return _artist; } set { _artist = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Album { get { return _album; } set { _album = value; } }
        public string Length { get { return _length; } set { _length = value; } }
        public ULib() {}
        public ULib(string path, string artist, string title, string album, string length) {
           Path = path;
           Artist = artist;
           Title = title;
           Album = album;
           Length = length;
        }
    }
