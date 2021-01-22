            Random rand = new Random();
            List<int> choices = new List<int>() { 1, 2, 3, 4 };
            while (choices.Count > 0)
            {
                int index = rand.Next() % choices.Count;
                int choice = choices[index];
                Console.WriteLine(choice);
                choices.RemoveAt(index);
            }
