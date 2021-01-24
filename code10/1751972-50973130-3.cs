    // Creates an instance of speech config with specified subscription key and service region.
    var config = SpeechConfig.FromSubscription("YourSubscriptionKey", "YourServiceRegion");
    
    // Creates a speech recognizer using file as audio input.
    // Replace with your own audio file name.
    using (var audioInput = AudioConfig.FromWavFileInput(@"whatstheweatherlike.wav"))
    {
        using (var recognizer = new SpeechRecognizer(config, audioInput))
        {
            // Performs recognition.
            var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);
            // Process result.
            // ...
        }
    }
