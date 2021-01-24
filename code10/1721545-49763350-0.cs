        //struct to hold the values
        struct highScoreEntry
        {
            public string PlayerName;
            public string Score;
            public highScoreEntry(string playerName, string playerScore)
            {
                PlayerName = playerName;
                Score = playerScore;
            }
        }
        List<highScoreEntry> allScores = new List<highScoreEntry>();
        using (System.IO.StreamReader sr = new StreamReader(@"Path to file"))
        {
            //skip the first line name and score titles
            string line = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] lineParts = line.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                allScores.Add(new highScoreEntry(lineParts[0], lineParts[1]));
            }
                
        }
        'sort in descending order using OrderByDescending
        List<highScoreEntry> sortedList = allScores.OrderByDescending(i => i.Score).ToList<highScoreEntry>();
        string highScoreText = "Player\tScore\r\n";
        foreach (highScoreEntry item in sortedList)
        {
            ''can be written directly into the textbox but for the example write it to a string
            highScoreText += item.PlayerName + "\t" + item.Score + "\r\n";
        }
        //add it to the textbox
        HighscoreRichTextBox.Text = highScoreText;
        }
