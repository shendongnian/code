    public void TextToSpeech(string text, string fileName)
    {
       using (var stream = File.Create(fileName))
       {
          SpeechSynthesizer speechEngine = new SpeechSynthesizer();
          speechEngine.SetOutputToWaveStream(stream);
          speechEngine.Speak(text);
          stream.Flush();
       }
    }
