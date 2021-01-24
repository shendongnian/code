    var sampleDoc = new SrgsDocument(@"en-US-sample.grxml");            
    sampleDoc.Culture = CultureInfo.GetCultureInfo("en-US");
    // this rule is the same as above
    var setTimerRule = new SrgsRule("SetTimer");            
    setTimerRule.Add(new SrgsItem("set timer for"));            
    setTimerRule.Add(new SrgsRuleRef(sampleDoc.Rules["Cardinal"]));            
    setTimerRule.Add(new SrgsItem("seconds"));            
    sampleDoc.Rules.Add(setTimerRule);
    
    // new rule, clear timer
    var clearTimerRule = new SrgsRule("ClearTimer");
    // just match this phrase
    clearTimerRule.Add(new SrgsItem("clear timer"));
    sampleDoc.Rules.Add(clearTimerRule);
    // new root rule, marching either set timer OR clear timer
    var rootRule = new SrgsRule("Times");
    rootRule.Add(new SrgsOneOf( // << OneOf is basically the same as Choice
        //               reference to SetTimer                                         
        new SrgsItem(new SrgsRuleRef(setTimerRule), 
            // assign command name. Both "command" and "settimer" are arbitrary names I chose
            new SrgsSemanticInterpretationTag("out = rules.latest();out.command = 'settimer';")),
        new SrgsItem(new SrgsRuleRef(clearTimerRule),
            // assign command name. If this rule "wins" - command will be cleartimer
            new SrgsSemanticInterpretationTag("out.command = 'cleartimer';"))
    ));
    sampleDoc.Rules.Add(rootRule);
    sampleDoc.Root = rootRule;
    var g = new Grammar(sampleDoc);
