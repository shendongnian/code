    class Finder {
        public int min, max;
        public bool CheckItem(int i) { return i >= min && i <= max;}
    }
    ...
    Finder finder = new Finder();
    finder.min = int.Parse(Console.Read());
    finder.max = int.Parse(Console.Read());
    List<int> filtered = data.FindAll(finder.CheckItem);
