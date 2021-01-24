    var items = new Dictionary<Language, Dictionary<string, string>>();
    items.Add(Language.English, new Dictionary<string, string>() );
    items.Add(Language.French, new Dictionary<string, string>() );
    
    var input = "ID_PLAYER_1==>Joueur 1---Player 1";
    // parts[0] = ID ; parts[1] = Content
    var parts = input.Split(new string[] { "==>" }, StringSplitOptions.None);
    // values[0] = french ; values[1] = english
    var values = parts[1].Split(new string[] { "---" }, StringSplitOptions.None);
    var key = parts[0]; // ID
    var french = values[0];
    var english = values[1];
    // put them in the Dictionary
    items[Language.English].Add(key, english);
    items[Language.French].Add(key, french);
