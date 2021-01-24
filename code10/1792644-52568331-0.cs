    private static List<string> WordList;
    async void GetWord(object sender, EventArgs e)
        {
            if (WordList == null) {
                WordsList = new List<string>();
                using (var stream = await FileSystem.OpenAppPackageFileAsync("txtWords.txt"))
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        WordsList.Add(line);
                    }
                }
            }
            string[] allWords = WordsList.ToArray();
            var random = new Random();
            int randNum = random.Next(1, 267751); /*Max lines in txtWords.txt */
            string newWord = allWords[randNum];
            GameWords.Text = newWord;
        }
