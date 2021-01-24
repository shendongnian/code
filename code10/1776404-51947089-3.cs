    string str="2+16-42X";
    
    StringBuilder currentNumber = new StringBuilder();
    List<string> tokens = new List<string>();
    foreach(char chr in str) {
        if (Char.IsDigit(chr)) {
            currentNumber.Append(chr);
        }
        else {
            if (currentNumber.Length > 0) {
                tokens.Add(currentNumber.ToString());
                currentNumber.Clear();
            }
            if (chr == '-') {
                currentNumber.Append(chr);
            }
            else {
                tokens.Add(chr.ToString());
            }
        }
    }
    if (currentNumber.Length > 0) {
        tokens.Add(currentNumber.ToString());
    }
