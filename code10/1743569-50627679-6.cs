    using (StreamReader sr = new StreamReader(filepath))
    {
        bool inarray = false;
        while (!sr.EndOfStream)
        {
            string s = sr.ReadLine();
            List<string> words = s.Split(' ').ToList();
            string[,] currentArray = null;
            int rowcount = 0;
            List<string[,]> arrays = new List<string[,]>();
            if (!inarray)
            {
                // not in an array, check for dimension numbers
                int x = 0;
                int y = 0;
                try
                {
                    x = int.Parse(words[0]);
                    y = int.Parse(words[1]);
                }
                catch
                {
                    continue; // couldn't parse it, try the next line
                }
                inarray = true;
                currentArray = new string[x, y];
                arrays.Add(currentArray);
                rowcount = 0;
            }
            else
            {
                // we're in an array
                // first check if we've hit the # stop character
                if (words[0].Equals("#"))
                {
                    inarray = false;
                    continue;
                }
    
                // otherwise, add this row to the array
                int i = 0;
                while(i< words.Count)
                {
                    currentArray[i, rowcount] = words[i];
                    i++;
                }
                rowcount++;
            }
        }
    }
