        private void Play_MediaSound()
        {
            // Create new media element dynamically
            MediaElement mediaElement = new MediaElement();
            // Reuse settings in XAML 
            mediaElement.Volume = mePlayClick.Volume;
            mediaElement.Source = mePlayClick.Source;
            mediaElement.AutoPlay = mePlayClick.AutoPlay;
            // WHen the media ends, remove the media element
            mediaElement.MediaEnded += (sender, args) =>
            {
                LayoutRoot.Children.Remove(mediaElement);
                mediaElement = null;
            };
            // Add the media element, must be in visual ui tree
            LayoutRoot.Children.Add(mediaElement);
            // When opened, play
            mediaElement.MediaOpened += (sender, args) =>
            {
                mediaElement.Play();
            };
        }
