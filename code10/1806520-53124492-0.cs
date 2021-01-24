    List<string> texts; // a list that holds all your strings
    int num_matched = 0;
    for (int i = 0; i < texts.Count; i++) {
        if (texts[i].Contains(userInput)) {
            Console.WriteLine("texts[i]");
            num_matched++;
        }
    }
    if (num_matched == 0) {
        Console.WriteLine("No match");
    }
