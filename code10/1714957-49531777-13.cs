    var num10To19 = new Choices(
        new SemanticResultValue("ten", 10),
        new SemanticResultValue("eleven", 11),
        new SemanticResultValue("twelve", 12),
        new SemanticResultValue("thirteen", 13),
        new SemanticResultValue("fourteen", 14),
        new SemanticResultValue("fifteen", 15),
        new SemanticResultValue("sexteen", 16),
        new SemanticResultValue("seventeen", 17),
        new SemanticResultValue("eighteen", 18),
        new SemanticResultValue("nineteen", 19)
    );
    var numTensFrom20To90 = new Choices(
        new SemanticResultValue("twenty", 20),
        new SemanticResultValue("thirty", 30),
        new SemanticResultValue("forty", 40),
        new SemanticResultValue("fifty", 50),
        new SemanticResultValue("sixty", 60),
        new SemanticResultValue("seventy", 70),
        new SemanticResultValue("eighty", 80),
        new SemanticResultValue("ninety", 90)
    );
    
    var num20to99 = new GrammarBuilder();
    // first word is "twenty", "thirty" etc
    num20to99.Append(numTensFrom20To90);
    // followed by ONE OR ZERO "digit" words ("one", "two", "three" etc)
    num20to99.Append(num1To9, 0, 1);
