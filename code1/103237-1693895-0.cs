    string sentence = "house in new york priced over $500000 with a swimming pool";
    string[] values = sentence.Split(new []{" in ", " priced over ", " with a "}, 
                                     StringSplitOptions.None);
    string type = values[0];
    string area = values[1];
    string price = values[2];
    string accessories = values[3];
