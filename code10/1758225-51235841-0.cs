        var enUS = new System.Globalization.CultureInfo("en-US");
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine(enUS);
        GrammarBuilder gb = new GrammarBuilder
        {
             Culture = enUS;
        }
        gb.Append("hello");
