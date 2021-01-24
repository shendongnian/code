    public static async Task ConvertTextToSpeechAndPlay(string text)
    {
        if (ttsMediaElement != null)
                ttsMediaElement.Stop(); //stop the reading that has not finished, if any
        
        var voice = ChooseVoice(text); //select the preferred voice chosen by the user
        if (voice != null)
        {
            using (var synth = new SpeechSynthesizer())
            {
                synth.Voice = voice;
                SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(text);
                ttsMediaElement = new MediaElement();
                
                ttsMediaElement.SetSource(stream, stream.ContentType);
                ttsMediaElement.Play();
            }
        }   
    }
