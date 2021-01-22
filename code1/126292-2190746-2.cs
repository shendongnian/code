    List<int> magicals = new List<int>();
    using (StreamReader reader = new StreamReader("GuessGame.txt"))
    {
        int magical = 0;
        string line = "";
        while (!String.IsNullOrEmpty(line = reader.ReadLine()))
        {
            if (Int32.TryParse(line, out magical))
                magicals.Add(magical);
        }
    }
