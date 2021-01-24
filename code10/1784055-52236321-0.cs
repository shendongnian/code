    private void GetPageAndLoadControls()
    {
        if (MPageDropDown.InvokeRequired)
        {
            MPageDropDown.Invoke((MethodInvoker)(() => GetPageAndLoadControls();));
            return;
        }
    
        var page = MPageDropDown.SelectedItem != null ? int.Parse(MPageDropDown.SelectedItem.ToString()) - 1 : 0;
        Task.Run(() => LoadMoviesControls(page));
    }
    private void LoadMoviesControls(int page)
    {
        var dict = new ConcurrentDictionary<string, Bitmap>();
        var movies = MovieList.Skip(page * Max).Take(Max).ToList();
        using (var client = new WebClient())
        {
            Parallel.ForEach(movies, (m) =>
            {
                Stream stream = null;
                Bitmap bmp = null;
                try
                {
                    if (!string.IsNullOrWhitespace(m.movie_Banner)
                    {
                        stream = client.OpenRead(s);
                        bmp =  new Bitmap(stream);
                        // Note: I am guessing on a key here, that maybe there is a title
                        // use whatever key is going to be best for your class
                        dict.TryAdd(m.movie_Title, new Bitmap(bmp, 139, 208));
                    }
                    else dict.TryAdd(m.movie_Title, Properties.Resources.no_image_available);
                }
                finally
                {
                    bmp?.Dispose();
                    stream?.Dispose();
                }
            });
        }
        // Here we have to invoke because the controls have to be created on
        // the UI thread. All of the other work has already been done in background
        // threads using the thread pool.
        MoviesFlowPanel.Invoke((MethodInvoker)() =>
        {
            foreach(var movie in movies)
            {
                Bitmap image = null;
                dict.TryGetValue(movie.movie_Title, out image);
                MoviesFlowPanel.Controls.Add(
                    new MovieControl(movie, image, ShowMError, this);
            }
        });
    }
    
    // Changed the constructor to now take an image as well, so you can pass in
    // the already resized image
    public MovieControl(Movies M1, Bitmap image, bool show, MainForm current)
    {
        InitializeComponent();
        Current = current;
        bunifuImageButton1.Image = image ?? Properties.Resources.no_image_available; // Sanity check
        bunifuImageButton1.Tag = M1;
    }
