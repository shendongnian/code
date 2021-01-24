        private static Task BadWordsWarn(SocketMessage msg)
        {
            string[] badWords = File.ReadAllLines(@"bad_words.txt");
            foreach(string badWord in badWords)
            {
                if (msg.Content.Replace(" ", "").ToLower().Contains(badWord.Replace(" ", "")))
                {
                    msg.DeleteAsync();
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;
        }
