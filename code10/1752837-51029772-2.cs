    private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var stream1 = await new SpeechSynthesizer().SynthesizeTextToStreamAsync("");
            player.Source = MediaSource.CreateFromStream(stream1, stream1.ContentType);
            player.MediaPlayer.Play();
            await BeginExtendedExecution();
            
            await Task.Delay(3000);
            var stream2 = await new SpeechSynthesizer().SynthesizeTextToStreamAsync("Test.");
            player.Source = MediaSource.CreateFromStream(stream2, stream2.ContentType);
            player.MediaPlayer.Play();
            Debug.WriteLine(player.MediaPlayer.AudioStateMonitor.SoundLevel);
        }
