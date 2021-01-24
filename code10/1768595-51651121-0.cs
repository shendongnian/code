            MediaPlayer bg;
        readonly CancellationTokenSource tokenSource = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();
            Bg_music();
        }
     
        private void Bg_music()
        {
            Task.Run(() =>
            {
                bg = new MediaPlayer();
                bg.Open(new Uri(@"D:\Songs\201145-Made_In_England__Elton_John__320.mp3"));
                bg.Play();
                bg.Play();
                while (true)
                {
                    if (tokenSource.Token.IsCancellationRequested)
                    {
                        bg.Stop();
                        break;
                    }
                }
            }, tokenSource.Token);
         
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
               tokenSource.Cancel();
        }
    }
