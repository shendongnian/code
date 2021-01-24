    List<string> sentences = new List<string>() { };
    List<string> titles = new List<string>() { };
    
    sentences.Add("The book named Lord of the Flies is a classic.");
    sentences.Add("The book named To Kill a Mockingbird is a classic.");
    sentences.Add("The book named The Catcher in the Rye is a classic.");
    sentences.Add("Hello");
    sentences.Add("The book named ");
    
                
    titles = sentences.Where(sentence => sentence.Length > "The book named ".Length + " is a classic".Length)
                .GroupBy(sentence => sentence.Substring(0, 15), sentence => sentence.Remove(sentence.Length - " is a classic".Length).Substring("The book named ".Length))
                .Where(g => g.Key == "The book named ")
                .SelectMany(g => g)
                .ToList();
    foreach (var title in titles)
        WriteLine(title);
