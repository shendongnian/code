    //create two lists to start
    string[] data = //whatever...
    List<int> numbers = new List<int>();
    List<string> words = new List<string>();
    //check each value
    foreach (string item in data) {
        if (Regex.IsMatch("^\d+$", item)) {
            numbers.Add(int.Parse(item));
        }
        else {
            words.Add(item);
        }
    }
