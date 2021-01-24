    var pbuilder = new PromptBuilder();
    var speaker2 = new SpeechSynthesizer();
    speaker2.Rate = -2;
    
    var culture = CultureInfo.GetCultureInfo("zh-CN");
    var voices = speaker2.GetInstalledVoices(culture);
    if (voices.Count > 0) //Chinese voices found
    {
        speaker2.SelectVoice(voices[0].VoiceInfo.Name); //you need to call this API
        pbuilder.AppendText("hello 你好");   
        speaker2.SpeakAsync(pbuilder);
    }
