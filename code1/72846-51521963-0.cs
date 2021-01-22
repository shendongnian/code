    static void Shuffle(List<int> cards)
        {
            Console.WriteLine("");
            Console.WriteLine("Shuffling");
            Console.WriteLine("---------");
            cards = cards.OrderBy(x => Guid.NewGuid()).ToList();
            foreach (var card in cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
