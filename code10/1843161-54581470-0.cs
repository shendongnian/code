        bool isPaused = false;
        if (mediaPlayer.Source != null)
        {
            if (isPaused)
            {
                mediaPlayer.Pause();
                isPaused = true;
                // I removed the 'btnPause.Content = null;' because it's not needed
                btnPause.Content = new Image
                {
                    Source = new BitmapImage(new Uri(@"Images/UI Icons/play.png", UriKind.Relative))
                };
             }
            else
            {
                mediaPlayer.Play();
                isPaused = false;
                btnPause.Content = new Image
                {
                    Source = new BitmapImage(new Uri(@"Images/UI Icons/pause.png", UriKind.Relative))
                };
             }
          }
