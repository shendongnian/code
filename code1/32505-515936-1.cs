    public enum Profession {
        Baker, Teacher, Coder, Miner
    }
    public class Record {
        public int FavoriteNumber {get;set;}
        public string Name {get;set;}
        public Profession Profession {get;set;}
    }
    class Table : Collection<Record>
    {
        protected void Rebuild()
        {
            indexName = null;
            indexNumber = null;
            indexProfession = null;
        }
        protected override void ClearItems()
        {
            base.ClearItems();
            Rebuild();
        }
        protected override void InsertItem(int index, Record item)
        {
            base.InsertItem(index, item);
            Rebuild();
        }
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            Rebuild();
        }
        protected override void SetItem(int index, Record item)
        {
            base.SetItem(index, item);
            Rebuild();
        }
        ILookup<int, Record> indexNumber;
        ILookup<string, Record> indexName;
        ILookup<Profession, Record> indexProfession;
        protected ILookup<int, Record> IndexNumber {
            get {
                if (indexNumber == null) indexNumber = this.ToLookup(x=>x.FavoriteNumber);
                return indexNumber;
            }
        }
        protected ILookup<string, Record> IndexName {
            get {
                if (indexName == null) indexName = this.ToLookup(x=>x.Name);
                return indexName;
            }
        }
        protected ILookup<Profession, Record> IndexProfession {
            get {
                if (indexProfession == null) indexProfession = this.ToLookup(x=>x.Profession);
                return indexProfession;
            }
        }
        public IEnumerable<Record> Find(int favoriteNumber) { return IndexNumber[favoriteNumber]; }
        public IEnumerable<Record> Find(string name) { return IndexName[name]; }
        public IEnumerable<Record> Find(Profession profession) { return IndexProfession[profession]; }
    }
