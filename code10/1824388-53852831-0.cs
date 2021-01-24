    public sealed partial class MainPage : Page
    {
        ObservableCollection<SongList> AllSongs;
        public MainPage()
        {
            this.InitializeComponent();
            AllSongs = new ObservableCollection<SongList>();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            AllSongs= new ObservableCollection<SongList>( await GetSongListsAsync("drake"));
            SongListView.ItemsSource = AllSongs;
            base.OnNavigatedTo(e);
        }
       private  async Task<List<SongList>> GetSongListsAsync(string SingerName)
        {
            List<SongList> songs = new List<SongList>();
            HttpClient client = new HttpClient();
            var jsonData = await client.GetStringAsync("https://theaudiodb.com/api/v1/json/1/searchalbum.php?s=" + SingerName);
            var response = JsonConvert.DeserializeObject<RootObject>(jsonData);
            foreach (var song in response.album.FindAll(g => !string.IsNullOrEmpty(g.strAlbumThumb)))
            {
                var bytes = await new HttpClient().GetByteArrayAsync(song.strAlbumThumb);
                MemoryStream stream = new MemoryStream(bytes.ToArray());
                var ImageStream =stream.AsRandomAccessStream();
                var bitmapimage = new BitmapImage();
                await bitmapimage.SetSourceAsync(ImageStream);
                songs.Add(new SongList() { Image = bitmapimage, name = song.strAlbum });
            }
            return songs;
        }
    }
    public class RootObject
    {
        public List<Album> album { get; set; }
    }
    public class Album
    {
        public string strAlbumThumb { get; set; }
        public string strAlbum { get; set; }
    }
    public class SongList
    {
        public ImageSource Image { get; set; }
        public string name { get; set; }
    }
