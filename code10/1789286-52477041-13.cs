    ObservableCollection<Video> datasource = new ObservableCollection<Video>();
    ObservableCollection<XFile> data = new ObservableCollection<XFile>();    
    try
        {
           //Your code here
           string jsonText1 = await response1.Content.ReadAsStringAsync();
           RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(jsonText1);
           itemGridView.ItemsSource = rootObject.videos.Select(x => new video { fname = x.fname, judul = x.judul, cover = x.cover }).ToList();   
           //Your code here        
        }
