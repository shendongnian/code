    public class MainViewModel
        {
            public MySongs MySongs { get; set; }
            
            public MainViewModel()
            {
                MySongs = new MySongs()
                {
                    Songs = new ObservableCollection<Song>()
                    {
                        new Song("Hey Jude", "The Beatles")
                    }
                };
            }
        }
