    var engine = new SpeechRecognitionEngine(CultureInfo.GetCultureInfo("en-US"));
    engine.SetInputToDefaultAudioDevice();
    var num1To9 = new Choices(
        new SemanticResultValue("one", 1),
        new SemanticResultValue("two", 2),
        new SemanticResultValue("three", 3),
        new SemanticResultValue("four", 4),
        new SemanticResultValue("five", 5),
        new SemanticResultValue("six", 6),
        new SemanticResultValue("seven", 7),
        new SemanticResultValue("eight", 8),
        new SemanticResultValue("nine", 9));
    var gb = new GrammarBuilder();
    gb.Culture = CultureInfo.GetCultureInfo("en-US");
    gb.Append("set timer for");
    gb.Append(num1To9);
    gb.Append("seconds");
    var g = new Grammar(gb);
    engine.LoadGrammar(g); // better not use LoadGrammarAsync
    engine.SpeechRecognized += OnSpeechRecognized;
    engine.RecognizeAsync(RecognizeMode.Multiple);
    Console.WriteLine("Speak");
    Console.ReadKey();
