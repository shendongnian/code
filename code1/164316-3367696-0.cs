    Choices commandtype = new Choices();
    commandtype.Add("search");
    commandtype.Add("print");
    commandtype.Add("open");
    commandtype.Add("locate");
    
    SemanticResultKey srkComtype = new SemanticResultKey("comtype",commandtype.ToGrammarBuilder());
     GrammarBuilder gb = new GrammarBuilder();
     gb.Culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
     gb.Append(srkComtype);
     gb.AppendDictation();
     Grammar gr = new Grammar(gb);
