    Dictionary<string, string> dict = new Dictionary<string, string>();
    dict.Add("word", "meaning");
    dict.Add("taciturn ", "Habitually silent; not inclined to talk");
    
    string s = "word abase";
    string formattedString = MyRegEx.FormatForDefns(s, dict);
