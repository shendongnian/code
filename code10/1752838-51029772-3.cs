    private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await BeginExtendedExecution();
            
            await Task.Delay(3000);
            var stream2 = await new SpeechSynthesizer().SynthesizeTextToStreamAsync("Test.");
            player.Source = MediaSource.CreateFromStream(stream2, stream2.ContentType);
            player.MediaPlayer.Play();
            Debug.WriteLine(player.MediaPlayer.AudioStateMonitor.SoundLevel);
        }
