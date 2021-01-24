        public static bool CanAppend(Domino domino, List<Domino> items)
        {
            return items.Count == 0 || items.Last().B == domino.A;
        }
        private static void PrintList(List<Domino> items)
        {
            Console.WriteLine();
            foreach (var item in items)
            {
                Console.Write(item.ToString());
            }
        }
