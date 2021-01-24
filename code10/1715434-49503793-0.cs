        public void Play(string Filename)
        {           
            Context context = Android.App.Application.Context;
            AssetManager assets = this.Assets;
            AssetFileDescriptor afd = assets.OpenFd(Filename);
            player = new MediaPlayer();
            player.SetDataSource(afd);
            player.Prepare();
            player.Start();
        }
