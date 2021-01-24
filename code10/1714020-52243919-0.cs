    using VideoLibrary;
    
    :
    :
    
    public class ytMetadata {
     public string uri;
     public string title;
     public string fullName;
     public VideoFormat format;
     public int resolution;
     public ytMetadata (string u, string t, string n, VideoFormat f, int r) {
      uri = u; title = t; fullName = n, format = f, resolution = r;
     }
    }
    
    public ytMetadata getYTMetadata(string uri) {
     YouTube yt = YouTube.Default;
     YouTubeVideo ytv = yt.GetVideo(uri);
     return new ytMetadata(ytv.Uri, ytv.Title, ytv.FullName, ytv.Format, ytv.Resolution);
    }
