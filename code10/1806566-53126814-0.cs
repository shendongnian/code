    public String currentWord;
    
    private List<Text> letterViews = new List<Text>();
    private int curIndex = 0;
    void Start() {
        // Populate the list of views ONCE, don't look for them every single time
        letterViews = ... // How you do this is entirely up to you
    }
    void Update() {
        // ...
        if (Duelling) {
            // If we've gone through the whole word, we're good
            if (curIndex >= currentWord.Length) DuelWon();
            // Now check input:
            // Note that inputString, which I've never used before, is NOT a single character, but
            // you're using only its first character; I'll do the same, as your solution seems to work.
            if (Input.inputString[0] == currentWord[currentIndex]) {
                // If the correct character was typed, make the label red and increment index
                letterViews[currentIndex].color = Color.red;
                currentIndex++;
            }
            else DuelLost();
        }
    }
