    var sampleDoc = new SrgsDocument(@"en-US-sample.grxml");
    sampleDoc.Culture = CultureInfo.GetCultureInfo("en-US");
    // define new rule, named Timer
    SrgsRule rootRule = new SrgsRule("Timer");            
    // match "set timer for" phrase
    rootRule.Add(new SrgsItem("set timer for"));
    // followed by whatever "Cardinal" rule defines (reference to another rule)
    rootRule.Add(new SrgsRuleRef(sampleDoc.Rules["Cardinal"]));
    // followed by "seconds"
    rootRule.Add(new SrgsItem("seconds"));
    // add to rules
    sampleDoc.Rules.Add(rootRule);
    // make it a root rule, so that it will be used for recognition
    sampleDoc.Root = rootRule;
    var g = new Grammar(sampleDoc);
    engine.LoadGrammar(g); // better not use LoadGrammarAsync
    engine.SpeechRecognized += OnSpeechRecognized;
    engine.RecognizeAsync(RecognizeMode.Multiple);
