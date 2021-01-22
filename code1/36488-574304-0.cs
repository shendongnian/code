    class Searcher {
        public string itemType;
        public bool Find(SomeType item) {return item.Type == itemType;}
    }
    ...
    Searcher searcher = new Searcher();
    searcher.itemType = ...
    var subList = list.FindAll(searcher.Find);
