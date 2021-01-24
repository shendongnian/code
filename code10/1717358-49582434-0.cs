    int indexOfWhiteSpace(string input) {
        for (var i = 0; i < input.Length; i++) {
            if (char.IsWhiteSpace(input[i])) {
                return i;
            }
        }
        return -1;
    }
